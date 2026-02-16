namespace CineManagerWeb.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Film { get; set; }
        public int Disponibilita { get; set; }
        public int PostiLiberi { get; set; }
        public int PostiOccupati { get; set; } = 0;
        
        public void OccupaPosto()
        {
            if (Disponibilita > 0)
            {
                PostiOccupati++;
                Disponibilita--;
                PostiLiberi= Disponibilita;
            }
        }

        public void DisdiciPosto()
        {
            if (PostiOccupati > 0)
            {
                PostiOccupati--;
                Disponibilita++;
                PostiLiberi = Disponibilita;
            }
        }

    }
}
