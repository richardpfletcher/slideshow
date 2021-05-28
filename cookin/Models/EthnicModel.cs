using System.Collections.Generic;
using System.Web.Mvc;

using System.Xml.Serialization;

namespace Cook.Models
{
    [XmlRoot("EthnicEntity")]
    public class EthnicModel
    {
        [XmlElement("ethnic")]
        public string ethnic { get; set; }

        public List<SelectListItem> items = new List<SelectListItem>();
    }
}