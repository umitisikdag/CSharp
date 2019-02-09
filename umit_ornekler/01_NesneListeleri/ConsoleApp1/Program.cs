using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor
{
    class Program
    {
        static void Main(string[] args)
        {

            //Basit canli üretimi
            Canli pf = new Canli();  //Canli class inin ilk constructorunu kullaniyorum.
           
            //Attribute lara deger atamasi yapiyoruz
            pf.Name="Pofuduk";
            pf.Age=2;
            pf.Color="Siyah";

            string tagS = String.Format("{0} muz {1} yasinda {2} renkli bir canlidir",
                pf.Name,
                pf.Age,
                pf.Color
            );
            Console.WriteLine(tagS + pf.SesCikart());

            //Yeni bir canli listesi olusturmak
            List<Canli> canlilistesi= new List<Canli>();

            //Listeye canlilar eklemek
            canlilistesi.Add(new Canli("Tekir", 5, "Gri"));  //Bu kez ikinci constructor u kullaniyorum
            canlilistesi.Add(new Canli("Kopuk", 6, "Beyaz"));
            canlilistesi.Add(new Canli("Pamuk", 3, "Beyaz"));


            //Liste index degeri ile attribute value getirmek
            Console.WriteLine(canlilistesi[0].Age+"\n");  //Tekir in yasi gelir
            Console.WriteLine(canlilistesi[1].Age+"\n"); //Kopuk un yasi gelir

            //Tum canlilarin adlarini yazdir
            for(int i=0;i<canlilistesi.Count();i++)
            {
                Console.WriteLine(canlilistesi[i].Name + "\n");
            }

            //Her hangi bir attribute un aldigi degere gore canli bulmak
            Canli bulunan=canlilistesi.Find(i => i.Age == 3);   //Yasi uc olan canliyi bul ve bulunan objesi ne ata

            //Bulunan canli nin rengini yazdir
            Console.WriteLine(bulunan.Color);

            //Sub class lar ile benzer islemler
            List<Fare> farelistesi = new List<Fare>();
            farelistesi.Add(new Fare());
            farelistesi.Add(new Fare("Jerry", 7, "Gri"));

            Console.WriteLine(farelistesi[0].SesCikart());

            Console.WriteLine(farelistesi[1].Name);

                Console.ReadKey();
        }
    }

    public class Canli
    {
        //Attribute tanimlarimiz
        public string Name { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }

        //Constructor Metod 1 Tanimimiz
        public Canli() { }

        //Constructor Metod 2 Tanimimiz
        public Canli(string N,int A,string C)
        {
            Name = N;
            Age = A;
            Color = C;
        }

        //Metod Tanimimiz
        public string SesCikart() { return "\nMeow, meow!\n"; }
    }

    public class Fare:Canli

    {
        public Fare() {}
        public Fare(string N, int A, string C)
        {
            Name = N;
            Age = A;
            Color = C;
        }
        public new string SesCikart() { return "\nkirp,kirp!\n"; }

    }
  



}

