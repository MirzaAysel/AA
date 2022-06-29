using DAL29.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL29.Models
{
    public class Card :IBase
    {
        public string Icon { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
    }
}
