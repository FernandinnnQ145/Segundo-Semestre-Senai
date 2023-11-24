import React, { useState, useEffect } from 'react';
import Title from '../../Components/Title/Title';
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';
import eventImage from '../../assets/images/evento.svg';
import { Input } from '../../Components/FormComponents/FormComponents';
import { Button } from '../../Components/FormComponents/FormComponents';
import { Select } from '../../Components/FormComponents/FormComponents';
import TableE from './TableE/TableE';
import api from '../../Services/Service';
import Notification from '../../Components/Notification/Notification';
import Spinner from '../../Components/Spinner/Spinner';


const EventosPage = () => {
    const [frmEdit, setFrmEdit] = useState(false);
    const [nome, setNome] = useState("");
    const [descricao, setDescricao] = useState("");
    const [tipoEvento, setTipoEvento] = useState([]);
    const [data, setData] = useState("");
    const [eventos, setEventos] = useState([]);
    const [notifyUser, setNotifyUser] = useState({});
    const [showSpinner, setShowSpinner] = useState(false);
    const [idEvento, setIdEvento] = useState("");
    const [idTipoEvento, setIdTipoEvento] = useState("");
    const [idInstituicao, setIdInstituicao] = useState("e981052e-4b4d-4beb-a7e6-c72e2121ccfa")




    useEffect(() => {
        //chamar a api
        async function getListarEventos() {
            setShowSpinner(true)
            try {
                const promise = await api.get(
                    "/Evento"
                
                );
                const promesa = await api.get(
                    "/TiposEvento"
                )
                setEventos(promise.data);
                setTipoEvento(promesa.data);
            } catch (error) {
                console.error("Erro : " + error);
                alert("Erro ao carregar os eventos");
            }
            setShowSpinner(false)
        }

        getListarEventos();
        console.log("A HOME FOI MONTADA!")
    }, []);



    async function handleUpdate(e) {
        e.preventDefault();

        try {
            const retorno = await api.put(`/Evento/${idEvento}`, {
                nomeEvento: nome,
                descricao,
                dataEvento: data,
                idTipoEvento: idTipoEvento,
                idInstituicao
            })
            
            const retornoGet = await api.get("/Evento")
            setEventos(retornoGet.data)
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Atualizado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });
            ResetForm();
            setFrmEdit(false)

        } catch (error) {
            alert("Deu ruim")
        }
    }

    async function handleSubimit(e) {
        e.preventDefault()
        if (nome.trim().length < 3) {
            setNotifyUser({
                titleNote: "Aviso",
                textNote: `nome deve possuir mais de 3 caracteres`,
                imgIcon: "warning",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });
            return;
        }

        try {
            const retorno = await api.post("/Evento", { 
                nomeEvento: nome, 
                descricao: descricao, 
                idTipoEvento: idTipoEvento, 
                dataEvento: data, 
                idInstituicao: idInstituicao 
            })
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Cadastrado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });
            console.log(retorno.data);
            ResetForm();
            const retornoGet = await api.get("/Evento")
            setEventos(retornoGet.data)

        } catch (error) {
            console.log("Deu erro na api")
        }
    }

    function ResetForm(){
        setNome("");
        setIdEvento("");
        setData("");
        setDescricao("");
        setIdTipoEvento("")
    }




    //TROCAR PARA A TELA DE EDICAO
    async function showUpdateForm(idElemento) {
        setFrmEdit(true);
        //Fazer um get para pegar os dados
        
        try {
            const retorno = await api.get('/Evento/'+ idElemento)

            
            setNome(retorno.data.nomeEvento)
            setDescricao(retorno.data.descricao)
            setIdTipoEvento(retorno.data.idTipoEvento)
            setData(retorno.data.dataEvento.substr(0,10))
            setIdEvento(retorno.data.idEvento)
        } catch (error) {
            alert("Nao foi possivel mostrar a tela de edicão. Tente novamente")
            console.log(error);
        }
    }







    async function handleDelete(idEvento) {
        try {
            const retorno = await api.delete(`/Evento/${idEvento}`)
            const retornoGet = await api.get("/Evento")
            setEventos(retornoGet.data)
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Deletado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
            });
        } catch (error) {
            console.log("Erro ao excluir");
        }

    }

    function editActionAbort() {
        setFrmEdit(false);
        ResetForm();
    }




    return (
        <MainContent>
            <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
            {showSpinner ? <Spinner /> : null}
            <section className="cadastro-evento-section">
                <Container>
                    <div className="cadastro-evento__box">
                        <Title
                            titleText={"Eventos"}
                        />


                        <ImageIllustrator
                            alterText={""}
                            imageRender={eventImage}
                        />

                        <form className="ftipo-evento" onSubmit={frmEdit ? handleUpdate : handleSubimit}>
                            {!frmEdit ?
                                (<>
                                    {/* ******************************Cadastrar****************************** */}


                                    {/* Nome */}
                                    <Input
                                        id={"id"}
                                        placeholder={"Nome"}
                                        name={"nome"}
                                        type={"text"}
                                        required={"required"}
                                        value={nome}
                                        manipulationFunction={
                                            (e) => {
                                                setNome(e.target.value)
                                            }
                                        }
                                    />
                                    {/* Descricao */}
                                    <Input
                                        id={"id"}
                                        placeholder={"Descricao"}
                                        name={"descricao"}
                                        type={"text"}
                                        required={"required"}
                                        value={descricao}
                                        manipulationFunction={
                                            (e) => {
                                                setDescricao(e.target.value)
                                            }
                                        }
                                    />

                                    {/* Tipo Evento */}
                                    <Select
                                     id={"id"}
                                     name={"tipo"}
                                     required={"required"}
                                     dados={tipoEvento}
                                     defaultValue={idTipoEvento}
                                     manipulationFunction={(e) =>{
                                        setIdTipoEvento(e.target.value)
                                     }}
                                    />


                                    {/* Data */}
                                    <Input
                                        id={"data"}
                                        name={"data"}
                                        type={"date"}
                                        required={"required"}
                                        value={data}
                                        manipulationFunction={
                                            (e) => {
                                                setData(e.target.value)
                                            }
                                        }
                                    />

                                    {/* Botao para cadastrar */}
                                    <Button
                                        type={"subimit"}
                                        name={"cadastrar"}
                                        id={"cadastrar"}
                                        textButton={"Cadastrar"}
                                    />



                                </>)


                                :


                                (<>

                                    {/* ******************************Editar****************************** */}


                                    {/* Nome */}
                                    <Input
                                        id={"id"}
                                        placeholder={"Nome"}
                                        name={"nome"}
                                        type={"text"}
                                        required={"required"}
                                        value={nome}
                                        manipulationFunction={
                                            (e) => {
                                                setNome(e.target.value)
                                            }
                                        }
                                    />
                                    {/* Descricao */}
                                    <Input
                                        id={"id"}
                                        placeholder={"Descricao"}
                                        name={"descricao"}
                                        type={"text"}
                                        required={"required"}
                                        value={descricao}
                                        manipulationFunction={
                                            (e) => {
                                                setDescricao(e.target.value)
                                            }
                                        }
                                    />

                                    {/* Tipo Evento */}
                                    <Select
                                     id={"id"}
                                     name={"tipo"}
                                     required={"required"}
                                     dados={tipoEvento}
                                     defaultValue={idTipoEvento}
                                     manipulationFunction={(e) =>{
                                        setIdTipoEvento(e.target.value)
                                     }}
                                    />


                                    {/* Data */}
                                    <Input
                                        id={"data"}
                                        name={"data"}
                                        type={"date"}
                                        required={"required"}
                                        value={data}
                                        manipulationFunction={
                                            (e) => {
                                                setData(e.target.value)
                                            }
                                        }
                                    />

                                    <div className="buttons-editbox">
                                        <Button
                                            textButton="Atualizar"
                                            type="subimit"
                                            name="atualizar"
                                            id="atualizar"
                                            addidionalClass="button-component--middle"
                                        />


                                        <Button
                                            textButton="Cancelar"
                                            type="button"
                                            name="cancelar"
                                            id="cancelar"
                                            manipulationFunction={editActionAbort}
                                            addidionalClass="button-component--middle"
                                        />
                                    </div>

                                </>)}
                        </form>
                    </div>
                </Container>
            </section>




            <section className="lista-eventos-section">
                <Container>
                    <Title
                        titleText={"Lista de eventos"}
                        color='white'
                    />

                    <TableE
                        dados={eventos}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />
                </Container>
            </section>


        </MainContent>
    );
};

export default EventosPage;