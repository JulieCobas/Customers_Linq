namespace Customers_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            // Création d'un tableau de clients avec des objets anonymes. Chaque objet représente un client.
            var customers = new[] // Tableau d'objets dont la classe est anonyme
             {
                 // Chaque "new" crée un objet anonyme avec les propriétés spécifiées.
                new {
                    IDCustomer = 1, Firstname ="Orlando", Name="Gee",CompanyName="A Bike Store", Country="Spain"},
                new {
                    IDCustomer = 2, Firstname ="Donald", Name="Blanton",CompanyName="Grand Industries", Country="Italy"},
                new {
                    IDCustomer = 3, Firstname ="Jean-Luc", Name="Blanchard",CompanyName="SuperMan Industries", Country="Spain"},
                new {
                    IDCustomer = 4, Firstname ="Yves", Name="Ginier",CompanyName="Socerel", Country="Switzerland"}

            };
            
            //première façon
            //Console.WriteLine("=============Query 1 :===============");
            //IEnumerable<string> entreprises =
            //    customers.Select(client => client.CompanyName);

            //foreach (string cn in entreprises)
            //{
            //    Console.WriteLine(cn);
            //}

            //Console.WriteLine("=============Query 2 :===============");


            //seconde façon
            var query2 =
                from c in customers  // "c" représente chaque élément dans la collection "customers"
                where c.Country == "Spain"  // Filtrage pour ne sélectionner que les clients en Espagne
                select c.CompanyName; //Sélection des noms des entreprises
            
            foreach (string name in query2) // Affichage des résultats de la requête
            {
                Console.WriteLine(name);
            }


            // 3EME TECHNIQUE : Avec plusieurs champs retournés

            //Console.WriteLine("==============Query 3 :==============");

            var query3 =
                from c in customers
                where c.Country == "Spain"
                select (new { nom = c.CompanyName, pays = c.Country }); //Même syntaxe que le talbea du début dont le type est anonyme -> Fortement typi. le type n'est pas nommé
                                                                        // 2 proprités raccourcie qui comprendra Nom et Pays. 

            var toto = query3.ToList(); // Conversion de la requête en liste

            foreach (var client in query3)  // Affichage des résultats
            {
                Console.WriteLine(client.nom + " " + client.pays);
            }

            //Console.WriteLine("============Query 4 :================");

            var query4 =
             customers
                    .Where(c => c.Country == "Spain")
                    .OrderBy(c => c.Name)
                    .Select(c => new { c.Name, c.CompanyName });

            foreach (var client in query4)
            {
                Console.WriteLine(client.Name + " " + client.CompanyName);
            }
            
        }
    }
}