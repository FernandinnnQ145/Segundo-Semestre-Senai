import React, { useEffect, useState } from 'react';
import './HomePage.css'
import MainContent from '../../Components/MainContent/MainContent';
import Banner from '../../Components/Banner/Banner';
import VisionSection from '../../Components/VisionSection/VisionSection';
import ContactSection from '../../Components/ContactSection/ContactSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Container from '../../Components/Container/Container';
import Title from '../../Components/Title/Title';
import axios from 'axios';
const HomePage = () => {
    useEffect(() =>{
        //Chamar a api
        async function getProximosEventos(){
            try {
                const promise = await axios.get("http://localhost:5000/api/Evento/ListarProximos");
                console.log(promise.data)
                setNextEvent(promise.data)
            } catch (error) {
                alert("Deu ruim na api")
            }
        }
        getProximosEventos();
        console.log("A home foi montada")
    }, [])

    //Fake mock - api mocada
    const [nextEvent, setNextEvent] = useState([
        {id: 1, title: "EventoX", descricao: "Evento de Sql", data:"10/11/2023" },
        {id: 2, title: "EventoY", descricao: "Evento de C#", data:"19/11/2023" }
    ])



    return (
        



        <MainContent>
            <Banner />

            <section className='proximos-eventos'>

                <Container>
                    <Title
                    titleText={"Proximos Eventos"}/>
                    <div className="events-box">


                        
                            {nextEvent.map((e) => {
                                return(
                                    <NextEvent
                                    title={e.nomeEvento}
                                    description={e.descricao}
                                    eventDate={e.dataEvento}
                                    idEvento={e.id} />
                                )
                            })}

                          
                        
                       

                    </div>

                </Container>

            </section>


            <VisionSection />
            <ContactSection />
        </MainContent>
    );
};

export default HomePage;