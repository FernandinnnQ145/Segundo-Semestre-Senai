import React, { useState, useEffect } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from '../../Components/ImageIllustrator/ImageIllustrator';

import eventTypeImage from '../../assets/images/tipo-evento.svg'
import Container from "../../Components/Container/Container";
import { Input } from "../../Components/FormComponents/FormComponents";
import { Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Service";
import TableTp from "./TableTp/TableTp";
import Notification from "../../Components/Notification/Notification";

const TipoEventosPage = () => {



    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState("");
    const [notifyUser, setNotifyUser] = useState({});




    const [tipoEventos, setTipoEventos] = useState([]);

    useEffect(() => {
        //chamar a api
        async function getListarTipos() {
            try {
                const promise = await api.get(
                    "/TiposEvento"
                );
                setTipoEventos(promise.data);
            } catch (error) {
                console.error("Erro : " + error);
                alert("Erro ao carregar os tipos de eventos");
            }
        }

        getListarTipos();
        console.log("A HOME FOI MONTADA!")
    }, []);

    async function handleSubimit(e) {
        e.preventDefault()

        if (titulo.trim().length < 3) {
            alert("O titulo deve ter no minimo 3 caracteres")
            return;
        }

        try {
            const retorno = await api.post("/TiposEvento", { titulo: titulo })
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: `Cadastrado com sucesso!`,
                imgIcon: "success",
                imgAlt:
                  "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
                showMessage: true,
              });
            console.log(retorno.data);
            setTitulo(""); //Limpa a variavel
            const retornoGet = await api.get("/TiposEvento")
            setTipoEventos(retornoGet.data)

        } catch (error) {
            console.log("Deu erro na api")
            console.log(error);
        }

    }

    //Atualizacao dos dados
    function handleUpdate() {
        alert("Bora atualizar");
    }

    function editActionAbort() {

    }

    function showUpdateForm() {
        alert("Mostrando a tela de update")
    }






    async function handleDelete(idTipoEvento) {
        try {
            const retorno = await api.delete(`/TiposEvento/${idTipoEvento}`)
            const retornoGet = await api.get("/TiposEvento")
            setTipoEventos(retornoGet.data)
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






    return (



        <MainContent>
            <Notification {...notifyUser} setNotifyUser={setNotifyUser}/>
            {/* CADASTRO */}
            <section className="cadastro-evento-section">
                <Container>
                    <div className="cadastro-evento__box">
                        <Title titleText={"Página Tipos de Eventos"} />
                        <ImageIllustrator
                            alterText={"??????"}
                            imageRender={eventTypeImage}
                        />

                        <form className="ftipo-evento" onSubmit={frmEdit ? handleUpdate : handleSubimit}>

                            {!frmEdit ?
                                (<>
                                    {/* Cadastrar */}
                                    <Input
                                        id={"id"}
                                        placeholder={"Titulo"}
                                        name={"titulo"}
                                        type={"text"}
                                        required={"required"}
                                        value={titulo}
                                        manipulationFunction={
                                            (e) => {
                                                setTitulo(e.target.value)
                                            }
                                        }

                                    />


                                    <Button
                                        type={"subimit"}
                                        name={"cadastrar"}
                                        id={"cadastrar"}
                                        textButton={"Cadastrar"}
                                    />

                                </>)
                                :
                                (<p>Tela de Edição</p>)}


                            {/* Atualizar */}

                            {/* <Input
                                id={"id"}
                                placeholder={"Titulo"}
                                name={"titulo"}
                                type={"text"}
                                required={"required"}
                                value={""}

                            /> */}
                        </form>
                    </div>
                </Container>
            </section>


            {/* LISTAGEM DE TIPO DE EVENTOS */}
            <section className="lista-eventos-section">
                <Container>
                    <Title titleText={"Lista de Tipo de Eventos"} color="white" />

                    <TableTp
                        dados={tipoEventos}
                        fnUpdate={showUpdateForm}
                        fnDelete={handleDelete}
                    />


                </Container>
            </section>
        </MainContent>
    );
};

export default TipoEventosPage;