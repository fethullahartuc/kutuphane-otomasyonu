using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Model
{
    public class Yazarlar
    {
        public int Id { get; set; }
        public string YazarAdi { get; set; }

        public List<Kitaplar> Kitaplar { get; set; }

    }
}
