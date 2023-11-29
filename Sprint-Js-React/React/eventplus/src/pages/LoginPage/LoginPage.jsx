import React, { useContext, useState } from "react";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator"
import logo from "../../assets/images/logo-pink.svg";
import { Input } from '../../Components/FormComponents/FormComponents';
import { Button } from '../../Components/FormComponents/FormComponents';
import loginImage from "../../assets/images/login.svg";
import api from "../../Services/Service";
import "./LoginPage.css";
import { UserContext ,UserDecodeToken } from "../../context/AuthContext";


const LoginPage = () => {

    const [user, setUser] = useState({ email: "fe@adimin.com", senha: "123456" })
    const {userData, setUserData} = useContext(UserContext)


    const{} = useContext(UserContext)

    async function handleSubimit(e) {
        e.preventDefault();
        if (user.email.length >= 3 && user.senha.length > 3) {
            //Chamar api
            try {
                const promise = await api.post("/login", {
                    email: user.email,
                    senha: user.senha
                });

                

                const userFullToken = UserDecodeToken(promise.data.token)
                
                setUserData(userFullToken)
                console.log(userData);
                localStorage.setItem("token", userFullToken)


            } 
            
            catch (error) {
                console.log(error);
            }
        }
        else {
            alert("Preencha os campos corretamente")
        }
        
    }


    return (
        <div className="layout-grid-login">
            <div className="login">
                <div className="login__illustration">
                    <div className="login__illustration-rotate"></div>
                    <ImageIllustrator
                        imageRender={loginImage}
                        altText="Imagem de um homem em frente de uma porta de entrada"
                        className="login-illustrator "
                        additionalClass="login-illustrator"
                    />
                </div>

                <div className="frm-login">
                    <img src={logo} className="frm-login__logo" alt="" />

                    <form className="frm-login__formbox" onSubmit={handleSubimit}>
                        <Input
                            additionalClass="frm-login__entry"
                            type="email"
                            id="login"
                            name="login"
                            required={true}
                            value={user.email}
                            manipulationFunction={(e) => {
                                setUser({
                                    ...user,
                                    email: e.target.value.trim()
                                })
                            }}
                            placeholder="Username"
                        />
                        <Input
                            additionalClass="frm-login__entry"
                            type="password"
                            id="senha"
                            name="senha"
                            required={true}
                            value={user.senha}
                            manipulationFunction={(e) => {
                                setUser({
                                    ...user,
                                    senha: e.target.value.trim()

                                })
                            }}
                            placeholder="****"
                        />

                        <a href="" className="frm-login__link">
                            Esqueceu a senha?
                        </a>

                        <Button
                            textButton="Login"
                            id="btn-login"
                            name="btn-login"
                            type="submit"
                            addidionalClass="frm-login__button"

                        />
                    </form>
                </div>
            </div>
        </div>
    );
};

export default LoginPage
