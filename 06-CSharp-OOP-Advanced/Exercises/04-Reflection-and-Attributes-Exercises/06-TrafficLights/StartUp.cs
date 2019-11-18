namespace _06_TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] signals = Console.ReadLine()
                .Split();

            TrafficLight[] trafficLights = new TrafficLight[signals.Length];

            for (int i = 0; i < trafficLights.Length; i++)
            {
                trafficLights[i] = (TrafficLight)Activator.CreateInstance(typeof(TrafficLight), new object[] { signals[i] });
            }

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                List<string> lights = new List<string>();

                foreach (var light in trafficLights)
                {
                    light.Update();
                    var color = light.GetType().GetField("currentColor", BindingFlags.Instance | BindingFlags.NonPublic);
                    lights.Add(color.GetValue(light).ToString());
                }

                Console.WriteLine(string.Join(' ', lights));
            }
        }
    }
}
