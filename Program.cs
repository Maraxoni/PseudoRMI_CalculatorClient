using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace PseudoRMI_CalculatorClient 
{
    class CalculatorClient
    {
        static void Main(string[] args)
        {
            // Communication method
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            // Defining address
            System.ServiceModel.EndpointAddress httpEndpoint = new System.ServiceModel.EndpointAddress("http://192.168.50.183:8080/CalculatorService");
            // Dynamically creating channels that implement interface
            ChannelFactory<ICalculatorService> myChannelFactory = new ChannelFactory<ICalculatorService>(httpBinding, httpEndpoint);
            
            ICalculatorService wcfClient1 = myChannelFactory.CreateChannel();

            while (true)
            {
                Console.WriteLine("Enter operation or 'exit'");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;

                try
                {
                    // Wywołanie metody Calculate na usłudze
                    double result = wcfClient1.Calculate(input);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            myChannelFactory.Close();
        }
    }
}