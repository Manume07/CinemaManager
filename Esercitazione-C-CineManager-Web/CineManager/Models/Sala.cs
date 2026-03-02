namespace CineManagerWeb.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Film { get; set; }
        public int PostiLiberi { get; set; }
        public int Posti { get; set; }
        public int PostiOccupati { get; set; }
        public int IncassoSala
        {
            get
            {
                int baseIncasso = PostiOccupati * 5;
                return (int)baseIncasso;
                
            }
        }

        public void OccupaPosto()
        {
            if (PostiLiberi > 0)
            {
                PostiLiberi--; 
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