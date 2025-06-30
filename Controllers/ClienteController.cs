using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Register(string cpf, string nome = "Cliente")
        {
            if (!CpfValido(cpf))
            {
                return Json(new { valido = false, mensagem = "CPF inválido" });
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.CPF == cpf);
            if (cliente != null)
            {
                return Json(new { existe = true, valido = true });
            }
            else
            {
                var novoCliente = new Cliente { Nome = nome, CPF = cpf };
                _context.Clientes.Add(novoCliente);
                await _context.SaveChangesAsync();
                return Json(new { existe = false, valido = true });
            }
        }

        // Função utilitária para validar CPF
        private bool CpfValido(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf, digito;
            int soma, resto;
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}