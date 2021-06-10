using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class phanso
    {
        private int tuso, mauso;
        public int TUSO
        {
            set { tuso = value; }
            get { return tuso; }
        }
        public int MAUSO
        { set { mauso = value; }
            get { return mauso; }

        }
        // phuong thuc set get de gan va lay gia tri cua tuso va mauso
        public phanso cong(phanso a, phanso b )
        {
            phanso c = new phanso();
            c.tuso = a.tuso * b.mauso + a.mauso * b.tuso;
            c.mauso = a.mauso * b.mauso;
            return c;
        }
        public phanso tru(phanso a, phanso b)
        {
            phanso c = new phanso();
            c.tuso = a.tuso * b.mauso - a.mauso * b.tuso;
            c.mauso = a.mauso * b.mauso;
            return c;
        }
        public phanso nhan(phanso a, phanso b)
        {
            phanso c = new phanso();
            c.tuso = a.tuso * b.tuso;
            c.mauso = a.mauso * b.mauso;
            return c;
        }
        public phanso chia(phanso a, phanso b)
        {
            phanso c = new phanso();
            c.tuso = a.tuso * b.tuso;
            c.mauso = a.mauso * b.tuso;
            return c;
        }
        public int ucln()
        {
            int a = tuso;
            int b = mauso;
            if (a < 0) a = -a;
            while (a!=b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }
        public void rutgon()
        {
            int u = ucln();
            tuso = tuso / u;
            mauso = mauso / u;
        }

    }
}
