import React from 'react';
import './HomePage.css'
import MainContent from '../../Components/MainContent/MainContent';
import Banner from '../../Components/Banner/Banner';
import VisionSection from '../../Components/VisionSection/VisionSection';
import ContactSection from '../../Components/ContactSection/ContactSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Container from '../../Components/Container/Container';
import Title from '../../Components/Title/Title';
const HomePage = () => {
    return (
        <MainContent>
            <Banner />

            <section className='proximos-eventos'>

                <Container>
                    <Title
                    titleText={"Proximos Eventos"}/>
                    <div className="events-box">


                        <NextEvent
                            title={"Evento x"}
                            description={"Evento legal"}
                            eventDate={"14/03/2024"}
                            idEvento={"dfvbrfedw"} />
                        <NextEvent
                            title={"Evento x"}
                            description={"Evento legal"}
                            eventDate={"14/03/2024"}
                            idEvento={"dfvbrfedw"} />
                        <NextEvent
                            title={"Evento x"}
                            description={"Evento legal"}
                            eventDate={"14/03/2024"}
                            idEvento={"dfvbrfedw"} />
                        <NextEvent
                            title={"Evento x"}
                            description={"Evento legalaaaaaaaaaaaa aaaaaaaaaa aaaaaaaa"}
                            eventDate={"14/03/2024"}
                            idEvento={"dfvbrfedw"} />
                        
                       

                    </div>

                </Container>

            </section>


            <VisionSection />
            <ContactSection />
        </MainContent>
    );
};

export default HomePage;