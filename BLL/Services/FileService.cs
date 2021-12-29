using BLL.Interfaces;
using DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FileService : IFile
    {
        IUnitOfWork _uow;
        public FileService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void PrintChck(int orderID)
        {
            string file = @"OrderCheck.pdf";
            var order = _uow.Orders.Get(orderID);
            var customer = _uow.Customers.Get(order.customer);
            var strings = _uow.OrdStrings.GetList()
                .Where(i => i.ord == orderID)
                .Join(_uow.Goods.GetList(), i => i.good, g => g.id, (i, g) => new { i.amount, i.cost, g.name }).ToList();

            FileStream fs = new FileStream(file, FileMode.Create);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            BaseFont baseFont = BaseFont.CreateFont("arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font headerFont = new Font(baseFont, 18, Font.BOLD);
            Font header2Font = new Font(baseFont, 16, Font.BOLD);
            Font defaultFont = new Font(baseFont, 14);

            document.Open();

            Paragraph header = new Paragraph("Магазин ComputerDeviceShop", headerFont);
            Paragraph subHeader = new Paragraph("Чек", header2Font);
            header.Alignment = Element.ALIGN_CENTER;
            subHeader.Alignment = Element.ALIGN_CENTER;
            Paragraph separator = new Paragraph("***********************************************************************************", headerFont);
            separator.Alignment = Element.ALIGN_CENTER;
            Paragraph productstart = new Paragraph("********************* Состав заказа *********************", header2Font);
            productstart.Alignment = Element.ALIGN_CENTER;
            Paragraph productend = new Paragraph("***********************************************************************************", headerFont);
            productend.Alignment = Element.ALIGN_CENTER;

            Paragraph date = new Paragraph($"Дата создания: {order.order_date.ToShortDateString()}", defaultFont);
            Paragraph login = new Paragraph($"Покупатель (логин): {customer.login}", defaultFont);
            Paragraph name = new Paragraph($"Покупатель (имя): {customer.name}", defaultFont);
            Paragraph ord = new Paragraph($"Статус: {_uow.Statuses.Get(order.status).name}", defaultFont);
            Paragraph id = new Paragraph($"Номер заказа: {order.id}", defaultFont);


            document.Add(header);
            document.Add(subHeader);
            document.Add(separator);
            document.Add(new Paragraph("\n"));
            document.Add(date);
            document.Add(login);
            document.Add(name);
            document.Add(ord);
            document.Add(id);
            document.Add(new Paragraph("\n"));
            document.Add(productstart);
            document.Add(new Paragraph("\n"));

            foreach (var item in strings)
            {
                Chunk glue = new Chunk(new VerticalPositionMark());
                Paragraph p = new Paragraph($"{item.name}: {item.amount} шт.", defaultFont);
                p.Add(new Chunk(glue));
                p.Add($"{item.cost:0.#} руб.");
                document.Add(p);
            }

            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph($"Итого: {order.total_cost:0.##} руб.", defaultFont));
            document.Add(new Paragraph("\n"));
            document.Add(separator);

            document.Close();
            writer.Close();
            fs.Close();

            Process iStartProcess = new Process();
            iStartProcess.StartInfo.FileName = file;
            iStartProcess.Start();
        }
    }
}
