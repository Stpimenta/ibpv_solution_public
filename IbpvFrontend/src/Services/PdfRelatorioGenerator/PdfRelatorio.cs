
using System.Globalization;
using IbpvDtos;
using IbpvFrontend.Components.Pages.Components;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


    
namespace IbpvFrontend.src.Services.PdfRelatorioGenerator
{
    public static class PdfRelatorio
    {
        public static MemoryStream GeneratePdfContribuicoes(IWebHostEnvironment env, List<ContribuicaoPagDTO>contribuicoes, List<GastoPagDTO>gastos, decimal totalEntradas, decimal totalSaidas, decimal currentCaixa, decimal valueLastCaixa, decimal saldoTotal, int mes,  List<(string, decimal)> histCaixa)
        {
            var logoPath = Path.Combine(env.WebRootPath, "images", "IBPV.jpg");
            var selectBox = Path.Combine(env.WebRootPath, "images", "selectBox.png");
            
             // Configura a licença para a versão Community
            QuestPDF.Settings.License = LicenseType.Community;

            

            // Cria o documento PDF com QuestPDF
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);

                    // Adiciona o cabeçalho com imagem
                    page.Header()
                        .BorderBottom((float)0.5)
                        .AlignCenter()
                        .AlignMiddle()
                        .Height(100)
                        .Row(row =>
                        {
                            row.RelativeColumn()
                                .Width(180) // Define a largura da coluna onde a imagem será colocada
                                .Image(
                                    logoPath) // Adiciona a imagem
                                .FitArea(); // Ajusta a imagem para ocupar a área disponível, preservando a proporção
                            row.RelativeColumn()
                                .AlignCenter()
                                .AlignMiddle()
                                .Column(column =>
                                {
                                    column.Item().Text("Relatório Financeiro")
                                        .FontSize(25);
                                    column.Item().Row(row =>
                                    {
                                        row.RelativeItem().Text(contribuicoes.FirstOrDefault().Caixa);
                                        row.RelativeItem().Text($"{Months.Meses.Find(m => m.Item1 == mes).Item2} de 2024");
                                    });
                                    
                                });
                        });


                    page.Content()
                        .AlignCenter()
                        .PaddingTop(15)
                        
                        .Column(column =>
                        {
                            column.Item().PaddingBottom(20).Row(row =>
                            {
                                row.RelativeColumn().Text("Entradas").AlignLeft().FontSize(20);
                            });
                            
                            column.Item().AlignCenter().PaddingBottom(10).Row(row =>
                            {
                                row.ConstantColumn(15).Padding(5).Text("").Bold();
                                if (contribuicoes.FirstOrDefault().TokenMembro is not null)
                                {
                                    row.ConstantColumn(250).Padding(5).Text("Código de Dizimista").Bold();
                                }
                                else
                                {
                                    row.ConstantColumn(250).Padding(5).Text("Descrição").Bold();
                                }
                                     
                                row.ConstantColumn(100).Padding(5).Text("Valor").Bold();
                            });
                            
                            
                            foreach (var contribuicao in contribuicoes)
                            {
                                column.Item().AlignCenter().Height(20).Row(row =>
                                {
                                    row.ConstantColumn(size:20)
                                        .Width(15) // Define a largura da coluna onde a imagem será colocada
                                        .Height(15) // Define a altura da coluna onde a imagem será colocada
                                        .Image(
                                            selectBox) // Adiciona a imagem
                                        .FitArea(); // Ajusta a imagem para ocupar a área disponível, preservando a proporção
                                    
                                    if (string.IsNullOrEmpty(contribuicao.TokenMembro))
                                    {
                                        row.ConstantColumn(250).Height(15).Text(contribuicao.Descricao);
                                    }
                                    else
                                    {
                                        row.ConstantColumn(250).Height(15).Text(contribuicao.TokenMembro);
                                    }
                                    
                                    row.ConstantColumn(100).Height(15)
                                        .Text(contribuicao.Valor.ToString("C", new CultureInfo("pt-BR")));
                                    
                                });
                            }
                            
                            column.Item().AlignCenter().PaddingTop(10).Text($"Total de entradas: {totalEntradas.ToString("C", new CultureInfo("pt-BR"))}");
                            column.Item().AlignCenter().Text($"Saldo para {Months.Meses.Find(m=>m.Item1 == mes).Item2}: {valueLastCaixa.ToString("C", new CultureInfo("pt-BR"))}");
                            column.Item().AlignCenter().Text($"Saldo Total: {saldoTotal.ToString("C", new CultureInfo("pt-BR"))}");
                            
                            column.Item().PageBreak();
                            
                            column.Item().Row(row =>
                            {
                                row.RelativeColumn().Text("Saidas").AlignLeft().FontSize(20);
                                
                                 column.Item().AlignCenter().PaddingBottom(10).Row(row =>
                                {
                                    row.ConstantColumn(250).Padding(5).Text("Descrição").Bold();
                                    row.ConstantColumn(100).Padding(5).Text("Valor").Bold();
                                });
                            
                            
                                foreach (var gasto in gastos)
                                {
                                    column.Item().AlignCenter().Height(20).Row(row =>
                                    {
                                        row.ConstantColumn(size:20)
                                            .Width(15) // Define a largura da coluna onde a imagem será colocada
                                            .Height(15) // Define a altura da coluna onde a imagem será colocada
                                            .Image(
                                                selectBox) // Adiciona a imagem
                                            .FitArea(); // Ajusta a imagem para ocupar a área disponível, preservando a proporção
                                        
                                       
                                        row.ConstantColumn(250).Height(15).Text(gasto.Descricao);
                                        row.ConstantColumn(100).Height(15)
                                            .Text(gasto.Valor.ToString("C", new CultureInfo("pt-BR")));
                                        
                                    });
                                }
                                
                                
                                column.Item().AlignCenter().PaddingTop(10).Text($"Total de saidas: {totalSaidas.ToString("C", new CultureInfo("pt-BR"))}");
                                column.Item().AlignCenter().Text($"Saldo para {Months.Meses.Find(m=>m.Item1 == mes + 1).Item2}: {currentCaixa.ToString("C", new CultureInfo("pt-BR"))}");
                                
                            });
                            column.Item().PageBreak();
                            
                            column.Item().PaddingBottom(20).Row(row =>
                            {
                                row.RelativeColumn().Text("Resumo de Saldos").AlignLeft().FontSize(20);
                            });
                            
                             column.Item().Row(row =>
                            {
                                foreach (var hist in histCaixa)
                                {
                                    column.Item().AlignCenter().Height(20).Row(row =>
                                    {
                                        row.ConstantColumn(250).Height(15).Text(hist.Item1);
                                        row.ConstantColumn(100).Height(15)
                                            .Text(hist.Item2.ToString("C", new CultureInfo("pt-BR")));
                                       
                                    });
                                    
                                    if (hist == histCaixa.Last())
                                    {
                                        decimal total = histCaixa.Sum(c => c.Item2);
                                        column.Item().AlignCenter().Height(20).Row(row =>
                                        {
                                            row.ConstantColumn(250).Height(15).Text("Saldo total");
                                            row.ConstantColumn(100).Height(15)
                                                .Text(total.ToString("C", new CultureInfo("pt-BR")));
                                       
                                        });
                                    }
                                }
                                
                                column.Item().PaddingTop(50).AlignCenter().Width(250).BorderBottom((float)0.5).Text("Ass 1:").FontSize(10);
                                column.Item().PaddingTop(50).AlignCenter().Width(250).BorderBottom((float)0.5).Text("Ass 2:").FontSize(10);
                                column.Item().PaddingTop(50).AlignCenter().Width(250).BorderBottom((float)0.5).Text("Ass 3:").FontSize(10);
                            });
                            
                        });
                    
                    page.Footer()
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span("Página ");
                            text.CurrentPageNumber();
                            text.Span(" de ");
                            text.TotalPages();
                        });
                    
                });
            });

            // Salva o PDF em um arquivo
            using (var memoryStream = new MemoryStream())
            {
                document.GeneratePdf(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }

           
        }

    }
    
    
}