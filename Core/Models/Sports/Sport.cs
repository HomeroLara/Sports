using System;
namespace Sports.Core.Models.Sports
{
    public class Sport
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SportType SportType { get; set; }
        public string LogoUri { get; set; }
        public Sport()
        {
        }
    }
}
