import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import TipoEvento from './pages/TipoEvento/TipoEvento';
import EventosPage from './pages/EventosPage/EventosPage';

const Rotas = () => {
    return (
        <BrowserRouter>
        <Routes>
            <Route element={<HomePage/>} path='/' exact/>
            <Route element={<LoginPage/>} path='/login' />
            <Route element={<TipoEvento/>} path='/TipoEvento' />
            <Route element={<EventosPage/>} path='/EventosPage' />
        </Routes>
        </BrowserRouter>
    );
};

export default Rotas;