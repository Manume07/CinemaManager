namespace CineManagerWeb.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Film { get; set; }
        public int PostiLiberi { get; set; }
        public int Posti { get; set; }
        public int ScontoPercentuale { get; set; }
        public int IncassoSala
        {
            get
            {
                double baseIncasso = PostiOccupati * 5;
                if (ScontoPercentuale <= 0) return (int)baseIncasso;
                double discounted = baseIncasso * (1 - ScontoPercentuale / 100.0);
                return (int)Math.Round(discounted);
            }
        }

        public int PostiOccupati { get; set; }


        public void OccupaPosto()
        {
            if (PostiLiberi > 0)
            {
                PostiLiberi --;
                PostiOccupati++;
            }
        }


        public void DisdiciPosto()
        {
            if (PostiOccupati != Posti)
            {
                PostiLiberi++;
                PostiOccupati--;
  
            }
                
        }

         
        public void CambiaPosti(int nuovacapienza)
        {
            Posti = nuovacapienza;
            PostiLiberi = nuovacapienza;

        }

       
    }
}