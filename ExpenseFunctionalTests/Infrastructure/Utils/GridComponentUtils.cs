using System;
using System.Linq;
    using NUnit.Framework;
using OpenQA.Selenium;

namespace ExpenseFunctionalTests.Infrastructure.Utils
    {
        public class GridComponentUtils
        {
            public IWebDriver Driver;
            public IWebElement Grid { get; }
            private readonly IWebElement _headerContainerElement;
            private readonly IWebElement _bodyContainerElement;

            public GridComponentUtils(IWebElement el)
            {
                Grid = el;

                _headerContainerElement = Grid.FindElement(By.CssSelector("[data-test-id='grid-header']"));
                _bodyContainerElement = el;
            }

            private int GetColumnNumberByHeader(string columnName)
            {
                var cols = _headerContainerElement.FindElements(By.XPath(".//th")).ToList();
                var num = cols.FindIndex(x => x.Text == columnName);

                return num;
            }

            private IWebElement GetCellInRowByNum(IWebElement row, int num)
            {
                var cell = row.FindElements(By.XPath(".//td")).ToList()[num-1];
                return cell;
            }

            public IWebElement GetRowElementByNum(int rowNum)
            {
                var row = _bodyContainerElement.FindElement(By.XPath($".//tbody/tr[{rowNum+1}]"));

                return row;
            }

            public IWebElement GetCellByColumnNameAndRowNum(string columnName, int rowNum)
            {
                var colNum = GetColumnNumberByHeader(columnName);
                var row = GetRowElementByNum(rowNum+1);

                return GetCellInRowByNum(row, colNum);
            }

            public int GetRowNumByText(string receiptNname)
            {
                var gridRows = _bodyContainerElement.FindElements(By.CssSelector("[data-test-id='grid-row']"));
                foreach (var gridRow in gridRows)
                {
                    var firstColumn = gridRow.FindElement(By.CssSelector("[data-test-id='grid-name-column-cell']"));
                    if (firstColumn.Text.Contains(receiptNname))
                    {
                        return gridRows.IndexOf(gridRow);
                    }
                }
                return -1;
            }         
        }
    }
