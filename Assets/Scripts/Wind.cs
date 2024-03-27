public class Wind
{
    private static Wind instance;
    public static Wind Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Wind();
            }
            return instance;
        }
    }

    private float value = 9;
    public float Value { get => value; set => this.value = value; }
}
