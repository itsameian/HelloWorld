using HelloWorld.Interfaces;

/// <summary>
/// Factory class for creating IApiReader and ITextwriter implementations 
/// Should be instantiated via Unity.Resolve<Initiator>()
/// </summary>
public class Initiator
{
    private IApiReader _reader;
    private ITextWriter _writer;
    public Initiator(IApiReader reader, ITextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }
    public IApiReader GetReader()
    {
        return _reader;
    }
    public ITextWriter GetWriter()
    {
        return _writer;
    }
}