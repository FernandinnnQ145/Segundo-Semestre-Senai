import React, { useContext, useEffect, useState } from 'react';
import './HomePage.css'
import MainContent from '../../Components/MainContent/MainContent';
import Banner from '../../Components/Banner/Banner';
import VisionSection from '../../Components/VisionSection/VisionSection';
import ContactSection from '../../Components/ContactSection/ContactSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Container from '../../Components/Container/Container';
import Title from '../../Components/Title/Title';
import api from '../../Services/Service';
import { UserContext } from '../../context/AuthContext';
const HomePage = () => {
  const {userData} =useContext(UserContext)
    useEffect(() => {
      //chamar a api
      async function getProximosEventos() {
        try {
          const promise = await api.get(
            "/Evento/ListarProximos"
          );
          setNextEvents(promise.data);
        } catch (error) {
          console.error("Erro : " + error);
          alert("Erro ao carregar os eventos");
        }
      }
  
      getProximosEventos();
      console.log("A HOME FOI MONTADA!")
    }, []);
  
    // fake mock - api mocada
    const [nextEvents, setNextEvents] = useState([]);
  
    return (
      <MainContent>
        <Banner />
        <section className="proximos-eventos">
          <Container>
            <Title titleText={"Próximos Eventos"} />
  
            <div className="events-box">
              {nextEvents.map((event) => (
                <NextEvent
                  key={event.idEvento}
                  title={event.nomeEvento}
                  description={event.descricao}
                  eventDate={event.dataEvento}
                  idEvento={event.idEvento}
                />
              ))}
            </div>
          </Container>
          <VisionSection />
          <ContactSection />
        </section>
      </MainContent>
    );
  };
  
  export default HomePage;
  
  