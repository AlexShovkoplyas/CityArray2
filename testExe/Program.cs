using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;

namespace testExe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //// Complex model

            //var customer = new Customer
            //{
            //    Name = "George Costanza"
            //};
            //var order = new Order
            //{
            //    Customer = customer
            //};
            //var bosco = new Product
            //{
            //    Name = "Bosco",
            //    Price = 4.99m
            //};
            //order.AddOrderLineItem(bosco, 15);

            //Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDto>()
            //    .ForMember(d => d.CustomerName, 
            //        opt => opt.MapFrom(src => src.Customer.Name))
            //    );

            //var dto = Mapper.Map<Order, OrderDto>(order);

            //var o = Mapper.Map<OrderDto, Order>(dto);

            Mapper.Initialize(cfg => cfg.CreateMap<A1, A2>()
                .ForMember(dest => dest.Iddd, opt => opt.Ignore())
                );

            Mapper.Initialize(cfg => cfg.CreateMap<A1, A2>(MemberList.Source));
                //cfg.CreateMap<Source2, Destination2>(MemberList.None);
);

            var res = Mapper.Map<A1, A2>(new A1 { Id = 1 });

            //var calendarEvent = new CalendarEvent
            //{
            //    Date = new DateTime(2008, 12, 15, 20, 30, 0),
            //    Title = "Company Holiday Party"
            //};

            // Configure AutoMapper
            //Mapper.Initialize(cfg =>
            //  cfg.CreateMap<CalendarEvent, CalendarEventForm>()
            //    .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
            //    .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
            //    .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute)));

            // Perform mapping
            //CalendarEventForm form = Mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);

            Mapper.Configuration.AssertConfigurationIsValid();



            Console.ReadKey();

        }
    }

    class First
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
    }

    class Second
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }
    }

    class A1
    {
        public int Id { get; set; }
    }

    class A2
    {
        public int Iddd { get; set; }
    }

    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }

    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
    }
}
