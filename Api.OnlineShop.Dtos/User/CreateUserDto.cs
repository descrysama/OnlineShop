using System;
namespace Api.OnlineShop.Dtos
{
	public class createUserDto
	{
        public String Email { get; set; }

        public String Password { get; set; }

        public String Street { get; set; }

        public String City { get; set; }

        public String Country { get; set; }
    }
}

