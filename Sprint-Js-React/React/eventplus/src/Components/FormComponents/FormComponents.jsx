import React from 'react';
import './FormComponents.css';

export const Input = ({
    type,
    id,
    required,
    additionalClass = "",
    name,
    placeholder,
    manipulationFunction, 
    value
}) => {
    return (
        <input 
        type={type}
        id={id}
        name={name}
        value={value}
        required={required}
        className={`input-component ${additionalClass}`}
        placeholder={placeholder}
        onChange={manipulationFunction}
        autoComplete='off'
    />
    );
}

export const Button = ({ textButton, id, name, type, addidionalClass="", manipulationFunction }) => {
    return(
        <button 
        type={type}
        name={name}
        id={id}
        className={`button-component ${addidionalClass}`}
        onClick={manipulationFunction}
        >
            {textButton}
        </button>
    )
}