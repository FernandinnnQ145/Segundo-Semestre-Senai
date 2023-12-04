import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

// import dos componentes de página
import HomePage from "../Pages/HomePage/HomePage";
import TipoEventosPage from "../Pages/TipoEventosPage/TipoEventosPage";
import EventosPage from "../Pages/EventosPage/EventosPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import TestePage from "../Pages/TestePage/TestePage";
import EventosAlunoPage from "../Pages/EventosAlunoPage/EventosAlunoPage";

import Header from "../Components/Header/Header";
import Footer from "../Components/Footer/Footer";
import { PrivateRoute } from "./PrivateRoute";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />

        <Route
          element={
            <PrivateRoute redirectTo="/">
              <TipoEventosPage />
            </PrivateRoute>
          }
          path="/tipo-eventos"
        />

        <Route
          element={
            <PrivateRoute redirectTo="/">
              <EventosPage />
            </PrivateRoute>
          }
          path="/eventos"
        />
        <Route
          element={
            <PrivateRoute redirectTo="/">
              <EventosAlunoPage />
            </PrivateRoute>
          }
          path="/eventos-aluno"
        />

        
        <Route element={<LoginPage />} path="/login" />
        <Route element={<TestePage />} path="/testes" />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
