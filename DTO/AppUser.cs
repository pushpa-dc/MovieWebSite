using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebsite.DTO
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool isDeleted { get; set; }
        public string Img { get; set; }


    }
}