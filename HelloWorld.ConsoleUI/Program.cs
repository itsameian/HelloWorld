using HelloWorld.Interfaces;
using System;

namespace HelloWorld.ConsoleUI
{
    class Program
    {
        #region Private fields
        private static Uri uriAddress = new Uri("http://localhost:11361/");
        private static IApiReader _reader;
        private static  ITextWriter _writer;
        #endregion 

        static void Main(string[] args)
        {
            //initialize the Unity IoC Container and Dependency Injection
            Bootstrap.Init();
            Initiator init = DependencyInjector.Retrieve<Initiator>();

            //Instantiate the apireader and console writer objects
            _reader = init.GetReader();
            _writer = init.GetWriter();
            _reader.SetClient(uriAddress);

            //attempt to read from the Web API
            try
            {
                //Write out to the console Message 1 and 2 from the API
                _writer.Write(_reader.GetMessage(1).Result);
                _writer.Write("<Press any key to exit>");
                Console.ReadLine();
                _writer.Write(_reader.GetMessage(2).Result);

                //pause for 1 second and exit
                System.Threading.Thread.Sleep(1000);
            }
            //If an error occurs, print out teh error message and exit.
            catch(Exception ex)
            {
                _writer.Write(ex.InnerException.Message);
                _writer.Write("Please ensure the target API application is running, and the server is accessable");
                _writer.Write("<Press any key to exit>");
                Console.ReadLine();
            }
        }
    }
}
