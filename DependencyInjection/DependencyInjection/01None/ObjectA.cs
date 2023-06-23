namespace DependencyInjection._1None
{
    public class ObjectA
    {
        public void DoStuff()
        {
            // do some stuff

            // i need a ObjectB in order to do stuff, so i'll create one.
            var b = new ObjectB();

            b.DoStuff();
            
            // do some more stuff
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
