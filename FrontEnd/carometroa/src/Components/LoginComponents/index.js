// Libs
import React from 'react'
import { useForm } from "react-hook-form";
import { useHistory } from 'react-router-dom'

// Styles

import { Container, AsideLogin, Logo, FormLogin, InputLogin, ButtonLogin, ErroMsg, BannerLogin } from './styles'

//Images
import logo from '../../Images/logo.png'

//Directories../../Services/api/api
import api from '../../Services/api/apiAccount'

export default function BodyLogin() {
    
    //Memory
    // const [email, setEmail] = useState('')
    // const [pwd, set] = useState('')

    // Variables
    const {register, handleSubmit} = useForm();
    const history = useHistory();
    

    // Functions

    function ErroLoginData(){

        document.getElementById('erroMsgData').style.visibility = 'visible';

    }

    function NotErroLoginNull(){

        document.getElementById('erroMsgNull').style.visibility = 'hidden';

    }

    function ErroLoginNull(){

        document.getElementById('erroMsgNull').style.visibility = 'visible';

    }

    async function Autenticar(data){

        if(data.email != null && data.pwd != null){

            const response = await api.post('/signin', {

                email: data.email,
                senha: data.pwd

            })

            console.log(response);

            if(response.data.sucesso === true){

                localStorage.setItem('tokenUserUp', response.data.data.token)
                history.push('/Menu')

            }else{

                ErroLoginData();
                NotErroLoginNull();
            
            }

        }
        if(data.email === '' || data.pwd === '' ){

            ErroLoginNull();
        }

    }

    // Render

    return(
        
        <Container>
            <AsideLogin onSubmit={ handleSubmit(Autenticar) }>
                <Logo src={logo} />
                <FormLogin>
                    <InputLogin     placeholder='Email' {...register('email')} type='email'    />
                    <InputLogin     placeholder='Password' {...register('pwd')} type='password' />
                    <ButtonLogin    type='submit' value='Entrar'  />
                </FormLogin>
                <ErroMsg id='erroMsgData' >Erro ao fazer login, tente novamente.</ErroMsg>
                <ErroMsg id='erroMsgNull' >Preencha os Campos.</ErroMsg>
                {/* <RedirectPwd to='Home' >Esqueci minha senha</RedirectPwd> */}
            </AsideLogin>
            <BannerLogin/>
        </Container>

    )
}