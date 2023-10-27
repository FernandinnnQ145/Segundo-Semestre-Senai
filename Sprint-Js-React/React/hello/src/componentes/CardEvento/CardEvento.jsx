import React from "react";
import './CardEvento.css'

const Card = ({tituloCard, textoCard, nomeBotao}) => {
    return (
        <div className="card-evento">
            <h3 className="card-evento__titulo">{tituloCard}</h3>
            <p className="card-evento__text">{textoCard}</p>
            <a href="" className="card-evento__conection">{nomeBotao}</a>
        </div>
    )
}

export default Card;