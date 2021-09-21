<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var stringtoEncrypt = "Abc123$";

	//Sha1
	var encryptedSha1 = EncryptSha1(stringtoEncrypt);
	var hex = BitConverter.ToString(encryptedSha1).Replace("-", ""); //Comparing length to Base64
	var base64 = Convert.ToBase64String(encryptedSha1);
	
	hex.Dump("HEX");
	base64.Dump("BASE64");
}

private byte[] EncryptSha1(string stringToEncrypt)
{
	byte[] byteArray;

	using (var shaSHA1 = System.Security.Cryptography.SHA1.Create())
	{
		var inputEncodingBytes = Encoding.ASCII.GetBytes(stringToEncrypt);
		byteArray = shaSHA1.ComputeHash(inputEncodingBytes);
	}

	return byteArray;
}
