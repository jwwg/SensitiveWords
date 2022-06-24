using Microsoft.AspNetCore.Mvc;

public interface IWordMasker
{
    Task<string> Mask(string message);
}