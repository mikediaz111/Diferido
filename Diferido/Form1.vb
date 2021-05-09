Public Class frmCompra
    Dim productos As Integer
    Dim cprod As New C_Productos
    Private Sub frmCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        productos = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cprod.llenarArray(productos, Me.txtNombre.Text, Me.txtValor.Text, Me.txtPrecio.Text, Me.txtInventario.Text)
        productos = productos + 1

        Me.ComboBox1.Items.Clear()

        Dim cont As Integer
        cont = 0
        Do While cont < productos
            Me.ComboBox1.Items.Add(cprod.obtenerDatos(cont, 1))
            cont = cont + 1
        Loop

    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim precio As Double
            Dim row As Integer
            Dim iva As Double
            Dim cantidad As Double

            cantidad = Convert.ToDouble(Me.txtCantidad.Text)
            row = Me.ComboBox1.SelectedIndex
            precio = cprod.obtenerDatos(row, 3) * cantidad
            iva = cprod.calcularIva(precio)

            Me.txtIva.Text = iva.ToString()
            Me.txtVenta.Text = precio.ToString()
        End If

    End Sub
End Class

Public Class C_Productos
    Dim codigo As Integer
    Dim nombre As String
    Dim valor As Double
    Dim precioVenta As Double
    Dim cantidadInventario As Integer
    Dim arrProductos(5, 5) As String

    Sub llenarArray(cant As Integer, nombre As String, valor As String, precio As String, inventario As String)
        Dim codigo As Integer
        Dim pos As Integer

        codigo = cant + 1
        pos = cant

        arrProductos(pos, 0) = codigo.ToString()
        arrProductos(pos, 1) = nombre.ToString()
        arrProductos(pos, 2) = valor.ToString()
        arrProductos(pos, 3) = precio.ToString()
        arrProductos(pos, 4) = inventario.ToString()

    End Sub

    Function obtenerDatos(row As Integer, col As Integer)
        Return arrProductos(row, col)
    End Function



    Function calcularIva(precio)
        Dim iva As Double
        iva = (precio * 0.13)

        Return iva
    End Function

    Function venta(precio As Double, items As Integer)
        Dim total As Double

        total = precio * items

        Return total
    End Function
End Class