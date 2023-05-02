import { useEffect, useState, Fragment } from "react"
import logoNFC from "../../public/logo-nfc.png"
import Image from "next/image"
import { useRouter } from "next/router"
import axios from "axios"

export default function Invoice() {
  const [formFields, setFormFields] = useState([])
  const [cliente, setCliente] = useState([])
  const [endereco, setEndereco] = useState([])
  const [contato, setContato] = useState([])
  const router = useRouter()
  const { key_access } = router.query
  


  useEffect(() => {    
    async function getAllinvoices() {     
      try {        
        const url = 'https://localhost:7012/api/v1/notas-fiscais/buscar-pelo-uid/f28d11af-771a-4aba-9250-b903bfc208c3'
        const totalInvoices = await axios.get(url)
        setFormFields(totalInvoices.data.data)
        setCliente(totalInvoices.data.data.cliente.NomeCliente)
        setEndereco(totalInvoices.data.data.cliente.endereco.bairro)
        setContato(totalInvoices.data.data.cliente.contato.celularNumero)
        console.log("cliente", cliente)
        console.log("okokok",  formFields.cliente.nomeCliente)
      } catch(err) {
        console.log(err)
      }
    }
    getAllinvoices()
  }, [])



  function formatDateTime(dateTimeStr) {
    const dateObj = new Date(dateTimeStr);
    const year = dateObj.getFullYear();
    const month = (dateObj.getMonth() + 1).toString().padStart(2, '0');
    const day = dateObj.getDate().toString().padStart(2, '0');
    return `${day}/${month}/${year}`;
  }

  // const currentFormField = JSON.parse(localStorage.getItem("formFields")) || []
  // const invoice = currentFormField.find((data) => data.key_access === key_access)

 


  return (
    <Fragment>
      <div className="container min-h-screen ">
        <div class="header">
          <Image src={logoNFC} width={180} alt="Logo" />
          <div>
            <p>TechnoChem</p>
            <p>CNPJ: 50.138.763/0001-71</p>
            <p>Endereço: AV MONTE CASSINO, Nº 695</p>
            <p>Telefone: (81) 99154-4050</p>
          </div>
        </div>
        
        <div class="details">
          <div class="left">
            <p><strong>Cliente:</strong>{cliente}</p>
            <p><strong>Endereço: </strong>{endereco}</p>
            <p><strong>Telefone:</strong>{contato}</p>
          </div>
          {/* <div class="right">
            <p><strong>Data da compra:</strong> {formatDateTime(formFields.dataEnussai)}</p>
            <p><strong>Número da nota:</strong> {formFields.numeroNota}</p>
          </div> */}
        </div>
        <div class="items">
          <div class="item">
            <span><strong>Descrição do Produto</strong></span>
            <span class="price"><strong>Preço
            </strong></span>
          </div>
          {/* <div class="item">
            <span>{invoice.product}</span>
            <span class="price">{Number(formFields.product_value).toLocaleString('ja-JP', { style: 'currency', currency: 'BRL' })}</span>
          </div> */}
        </div>
        {/* <div class="total">
          <span>Total:</span>
          <span>{Number(invoice.product_value).toLocaleString('ja-JP', { style: 'currency', currency: 'BRL' })}</span>
        </div> */}
        <div class="absolute bottom-4 text-gray-500">
          <p>Esta nota fiscal foi gerada automaticamente pelo sistema.</p>
          <p>Para mais informações, entre em contato conosco pelo telefone (81) 9154-4050 ou pelo e-mail Contato@technochem.com.br</p>
        </div>
	    </div>
    </Fragment>
    // <div></div>
  )
}