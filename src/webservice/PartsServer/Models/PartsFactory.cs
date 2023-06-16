namespace PartsService.Models
{
    public static class PartsFactory
    {
        static object locker = new object();
        public static Dictionary<string, Tuple<DateTime, List<Part>>> Parts = new Dictionary<string, Tuple<DateTime, List<Part>>>();

        public static void Initialize(string authorizationToken)
        {
            lock (locker)
            {
                Parts.Add(authorizationToken,
                    Tuple.Create(DateTime.UtcNow.AddHours(1), DefaultParts.ToList()));
            }
        }

        private static IEnumerable<Part> DefaultParts
        {
            get
            {
                yield return new Part
                {
                    CarID = "0545685192",
                    Marka = "Toyota",
                    Model = "Yaris",
                    Rocznik = 2008,
                    Cena = 20000
                };
                yield return new Part
                {
                    CarID = "0273329829",
                    Marka = "Toyota",
                    Model = "Corolla",
                    Rocznik = 2018,
                    Cena = 50000
                };
                yield return new Part
                {
                    CarID = "0890917543",
                    Marka = "BMW",
                    Model = "X3",
                    Rocznik = 20198,
                    Cena = 60000
                };
            }
        }

        public static void ClearStaleData()
        {
            lock (locker)
            {
                var keys = Parts.Keys.ToList();
                foreach (var oneKey in keys)
                {
                    if (Parts.TryGetValue(oneKey, out Tuple<DateTime, List<Part>> result) &&
                        result.Item1 < DateTime.UtcNow)
                    {
                        Parts.Remove(oneKey);
                    }
                }
            }
        }

        static readonly Random Rng = new Random();
        public static string CreatePartID()
        {
            char[] ch = new char[10];
            for (int i = 0; i < 10; i++)
            {
                ch[i] = (char)('0' + Rng.Next(0, 9));
            }
            return new string(ch);
        }
    }
}
