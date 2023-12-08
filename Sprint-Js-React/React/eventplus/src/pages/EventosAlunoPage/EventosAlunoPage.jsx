import React, { useContext, useEffect, useState } from "react";
import Header from "../../Components/Header/Header";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "./TableEvA/TableEvA"
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
import api from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const [descricao, setDescricao] = useState("");
  const [idEvento, setIdEvento] = useState("")
  const [comentario, setComentario] = useState("")

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  useEffect(() => {
   

    loadEventsType();
  }, [tipoEvento, userData.userId]);


  async function loadEventsType() {


    try {
      if (tipoEvento === "1") {
        const promise = await api.get("/Evento")
        const promiseEvento = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`)

        const dadosMarcados = verificaPresenca(promise.data, promiseEvento.data)
        setEventos(promise.data)
        console.log(dadosMarcados);


      }
      else {
        let arrEventos = [];
        const promiseEvento = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`)
        promiseEvento.data.forEach((element) => {
          arrEventos.push({
            ...element.evento,
             situacao : element.situacao,
             idPresencaEvento: element.idPresencaEvento
            })
        });
        setEventos(arrEventos)

      }
    }

    catch (error) {
      console.log(error);
    }



  }

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      
      for (let i = 0; i < eventsUser.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;

          break;
        }
        
      }
      
    }
    return arrAllEvents
  }


  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  //Ler um comentario
  async function loadMyComentary() {
    const promiseComentario = await api.get(`/ComentariosEvento/BuscarPorIdUsuario?idUsuario=${userData.userId}&idEvento=${idEvento}`)
    setComentario(promiseComentario.data.descricao)
    console.log(promiseComentario);
    alert("Carregar um comentario")
  }

  //Cadastar comentario
  async function postMyComentary() {
    

  }

  const showHideModal = (idEvento) => {
    setShowModal(showModal ? false : true);
    setIdEvento(idEvento)
  };


  //Remove um comentario
  const commentaryRemove = async () => {
    alert("Remover o comentário");
  };

  async function handleConnect(idEvent, whatTheFunction, idPresencaEvento = null) {


    //Conectar ao evento
    if (whatTheFunction === "connect") {
      try {
        const promise = await api.post("/PresencasEvento", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent 
        })
        if(promise.status === 201){
          loadEventsType();
          alert("Presenca confirmada");
        }
      } catch (error) {
        console.log("Erro ao conectar");
        console.log(error);
      }
    return;
    }

    //Desconectar do evento
    const promiseDelete = await api.delete("/PresencasEvento/" + idPresencaEvento);
    if(promiseDelete.status === 204){
      loadEventsType();
      alert("Desconectado do evento")
    }
    

    
  }
  return (
    <>

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} additionalClass="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            mapOption={(opt) => {
              return <option key={opt.value} value={opt.value}>{opt.text}</option>
            }}
            addidionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnGet={loadMyComentary}
          fnPost={postMyComentary}
          fnDelete={commentaryRemove}
          comentaryText={comentario}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
