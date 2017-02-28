using System.Linq;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpenseFunctionalTests.Infrastructure.Utils
{
    public class GridComponentUtils
    {
        public IWebElement Grid { get; }
        private readonly IWebElement _headerContainerElement;
        private readonly IWebElement _bodyContainerElement;

        public GridComponentUtils(IWebElement el)
        {
            Grid = el;

            _headerContainerElement = Grid.FindElement(By.CssSelector(".row.items.panel"));
            _bodyContainerElement = Grid.FindElement(By.TagName("exp-populate-common-list"));
        }

        private int GetColumnNumberByHeader(string columnName)
        {
            var cols = _headerContainerElement.FindElements(By.XPath("./div")).ToList();
            var num = cols.FindIndex(x => x.Text == columnName);

            return num;
        }

        private IWebElement GetCellInRowByNum(IWebElement row, int num)
        {
            var cell = row.FindElements(By.CssSelector(".item.panel-body")).ToList()[num];
            return cell;
        }

        public IWebElement GetRowElementByNum(int rowNum)
        {
            var row = _bodyContainerElement.FindElement(By.XPath($"./div[{rowNum}]"));

            return row;
        }

        public IWebElement GetCellByColumnNameAndRowNum(string columnName, int rowNum)
        {
            var colNum = GetColumnNumberByHeader(columnName);
            var row = GetRowElementByNum(rowNum + 1);

            return GetCellInRowByNum(row, colNum);
        }

        public void VerifyIfRowExists(string receiptNname)
        {
            bool found = false;
            var GridContainer = Grid.FindElement(By.TagName("exp-common-list"));
            var GridRows = GridContainer.FindElements(By.ClassName("items"));
            foreach (var gridRow in GridRows)
            {
                var firstColumn = gridRow.FindElement(By.TagName("div"));
                if (firstColumn.Text.Contains(receiptNname))
                {
                    found = true;
                    break;
                }
            }
            Assert.IsTrue(found, "Could not find!");
        }

    }
}
