namespace MainProjectCORE.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        //Repositoryler entity dönerken serviceler direkt olarak API'nin isteyeceği Dto'yu dönerler.
    }
}
