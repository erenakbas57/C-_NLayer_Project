using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependencyResolvers.Ninject;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EF;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // bağımlılık olmaması için ninject kullandık (dependency injection)
            // new ile nesne üretmedik bağımlılık olmaması için 
            // IoC Container (Inversion of Control) Container ile nesneleri yönetiriz
            productManager = InstanceFactory.GetInstance<IProductService>();
            categoryManager = InstanceFactory.GetInstance<ICategoryService>();
        }

        IProductService productManager;
        ICategoryService categoryManager;
        Product selectedProduct;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
            
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = productManager.GetAll();
        }

        private void LoadCategories()
        {
            cbxCategoryName.DataSource = categoryManager.GetAll();
            cbxCategoryName.DisplayMember = "CategoryName";
            cbxCategoryName.ValueMember = "CategoryId";

            cbxAddCategory.DataSource = categoryManager.GetAll();
            cbxAddCategory.DisplayMember = "CategoryName";
            cbxAddCategory.ValueMember = "CategoryId";

            cbxUpdateCategory.DataSource = categoryManager.GetAll();
            cbxUpdateCategory.DisplayMember = "CategoryName";
            cbxUpdateCategory.ValueMember = "CategoryId";
        }

        private void cbxCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = productManager.GetProductsByCategory(Convert.ToInt32(cbxCategoryName.SelectedValue));
            }
            catch 
            {

            }
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxProductName.Text))
                {
                    LoadProducts();
                }
                else
                {
                    dgwProduct.DataSource = productManager.GetProductsByProductName(tbxProductName.Text);
                }
            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    CategoryId = Convert.ToInt32(cbxAddCategory.SelectedValue),
                    ProductName = tbxAddName.Text,
                    QuantityPerUnit = tbxAddQuantityPerUnit.Text,
                    UnitPrice = Convert.ToDecimal(tbxAddUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxAddUnitsInStock.Text)
                };
                productManager.Add(product);
                LoadProducts();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Doğrulama Hatası: " + exception.Message);
            }
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProduct = (Product)dgwProduct.CurrentRow.DataBoundItem;
            tbxUpdateName.Text = selectedProduct.ProductName;
            cbxUpdateCategory.SelectedValue = selectedProduct.CategoryId;
            tbxUpdateQuantityPerUnit.Text = selectedProduct.QuantityPerUnit;
            tbxUpdateUnitPrice.Text = selectedProduct.UnitPrice.ToString();
            tbxUpdateUnitsInStock.Text = selectedProduct.UnitsInStock.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productManager.Update(new Product
            {
                ProductId = selectedProduct.ProductId,
                CategoryId = Convert.ToInt32(cbxUpdateCategory.SelectedValue),
                ProductName = tbxUpdateName.Text,
                QuantityPerUnit = tbxUpdateQuantityPerUnit.Text,
                UnitPrice = Convert.ToDecimal(tbxUpdateUnitPrice.Text),
                UnitsInStock = Convert.ToInt16(tbxUpdateUnitsInStock.Text)
            });
            MessageBox.Show("Güncellendi");
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productManager.Delete(selectedProduct);
            LoadProducts();
        }
    }
}
