﻿using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Data;
using NutriFlowAPI.DTO.Produto;
using NutriFlowAPI.Models;
using NutriFlowAPI.Services.Produto;

namespace NutriFlowAPI.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int idProduto)
        {
            ResponseModel<ProdutoModel> resposta = new ResponseModel<ProdutoModel>();

            try
            {
                var produto = await _context.Produtos.
                    FirstOrDefaultAsync(produtoBanco => produtoBanco.Id == idProduto);

                if (produto == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado";

                    return resposta;
                }

                resposta.Dados = produto;
                resposta.Mensagem = "Produto localizado";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }

        }

        public async Task<ResponseModel<List<ProdutoModel>>> CriarProduto(ProdutoCriacaoDTO produtoCriacaoDTO)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = new ProdutoModel
                {
                    Produto = produtoCriacaoDTO.Produto,
                    Ativo = produtoCriacaoDTO.Ativo,
                };

                if (produtoCriacaoDTO.Imagem != null && produtoCriacaoDTO.Imagem.Length > 0)
                {
                    var nomeUnico = Guid.NewGuid().ToString() + Path.GetExtension(produtoCriacaoDTO.Imagem.FileName);
                    var pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens_produtos");
                    Directory.CreateDirectory(pasta);

                    var caminhoFisico = Path.Combine(pasta, nomeUnico);
                    using (var stream = new FileStream(caminhoFisico, FileMode.Create))
                    {
                        await produtoCriacaoDTO.Imagem.CopyToAsync(stream);
                    }

                    // Caminho público acessível
                    produto.Imagem = $"/imagens_produtos/{nomeUnico}";
                }

                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto criado com sucesso";

                return resposta;
            
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> EditarProduto(ProdutoEdicaoDTO produtoEdicaoDTO)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = await _context.Produtos
                    .FirstOrDefaultAsync(produtoBanco => produtoBanco.Id == produtoEdicaoDTO.Id);

                if (produto == null) 
                {
                    resposta.Mensagem = "Nenhum registro localizado";

                    return resposta;
                }

                produto.Produto = produtoEdicaoDTO.Produto;
                produto.Ativo = produtoEdicaoDTO.Ativo;

                if (produtoEdicaoDTO.Imagem != null && produtoEdicaoDTO.Imagem.Length > 0)
                {
                    var nomeUnico = Guid.NewGuid().ToString() + Path.GetExtension(produtoEdicaoDTO.Imagem.FileName);
                    var pasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens_produtos");
                    Directory.CreateDirectory(pasta);
                    var caminhoFisico = Path.Combine(pasta, nomeUnico);

                    using var stream = new FileStream(caminhoFisico, FileMode.Create);
                    await produtoEdicaoDTO.Imagem.CopyToAsync(stream);

                    produto.Imagem = $"/imagens_produtos/{nomeUnico}";
                }

                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto editado com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = await _context.Produtos
                    .FirstOrDefaultAsync(produtoBanco => produtoBanco.Id == idProduto);

                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";

                    return resposta;
                }

                _context.Remove(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto excluido com sucesso";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }

        }

        public async Task<ResponseModel<List<ProdutoModel>>> ListarProdutos()
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produtos = await _context.Produtos.ToListAsync();

                resposta.Dados = produtos;
                resposta.Mensagem = "Todos os produtos foram coletados";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }
    }
}
