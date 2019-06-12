namespace CipherInterface
{
    public interface ICipher
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}
