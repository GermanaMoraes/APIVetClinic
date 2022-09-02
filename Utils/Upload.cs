using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace APIVetClinic.Utils
{
    public static class Upload
    {
        //Upload

        public static string UploadFile(IFormFile arquivo, string[] extensoesPermitidas, string diretorio)
        {
            try
            {
                var pasta = Path.Combine("StaticFile", diretorio);
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), pasta);
                if (arquivo.Length > 0)
                {
                    string nomeArquivo = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');

                    //Validando se a extensao é permitida
                    if (ValidarExtensao(extensoesPermitidas, nomeArquivo))
                        {
                        var extensao = RetornarExtensao(nomeArquivo);
                        var novonome = $"{Guid.NewGuid()}.{extensao}";
                        var caminhoCompleto = Path.Combine(caminho, novonome);

                        //salvando

                        using(var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            arquivo.CopyTo(stream);
                        }
                        return novonome;
                    }
                }

                return null;
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }
        }

        //Validar extensão

        public static bool ValidarExtensao(string[] extensoesPermitidas, string nomeArquivo)
        {
            string extensao = RetornarExtensao(nomeArquivo);
            foreach (string ext in extensoesPermitidas)
            {
                if (ext == extensao)
                {
                    return true;
                }
            }
            return false;
        }
        //Retornar Extensão
        public static string RetornarExtensao(string nomeArquivo)
        {
            string[] dados = nomeArquivo.Split('-');
            return dados[dados.Length - 1];
        }
    }
}
