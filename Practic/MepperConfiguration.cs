internal class MepperConfiguration
{
    private Action<object> value;

    public MepperConfiguration(Action<object> value)
    {
        this.value = value;
    }
}