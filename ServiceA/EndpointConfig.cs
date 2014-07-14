
namespace ServiceA
{
    using System;
    using System.Threading.Tasks;
    using Messages;
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
    }

    public class MyClass : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.Out.WriteLine("The ServiceA endpoint is now started and subscribed: " + DateTime.Now.ToString());

            Parallel.For(0, 5000, i => Bus.Send("ServiceA", new CommandA() { Id=i}));
          
        }

        public void Stop()
        {

        }
    }
}
