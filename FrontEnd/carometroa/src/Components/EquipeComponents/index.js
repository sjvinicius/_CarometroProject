import React, { useEffect, useState } from 'react'

import { Container, BackgroundEquipe, ContentEquipe,  WrapperNav, RedirectButton, WrapperForm, FormSearch, InputSearch, ButtonSearch, ListTeam, ItemList, ToolBar, IconExclude, TextTeam, TittleTeam } from './styles'
import { TopPage, IconRedirect, WrapperTittle, IAluno, TittleAluno, Logo } from '../AlunosComponents/styles'

import { ArrowReturnLeft } from '@styled-icons/bootstrap/ArrowReturnLeft'

import team from '../../Images/IconTeam.png'
import logo from '../../Images/logo.png'

import api from '../../Services/api/apiAccount'

export default function BodyEquipe(){

    const [colaboradores, setColaboradores] = useState([])
    const [administradores, setAdministradores] = useState([])

    async function BuscarColaboradores(){

        const response = await api.get('/colabs', 
        {

            headers : {

                'Authorization' : 'Bearer ' + localStorage.getItem('tokenUserUp')

            }

        })

        if(response.data.sucesso === true ){

            setColaboradores(response.data.data)
        }

    }

    async function BuscarAdministradores(){

        const response = await api.get('/admins', 
        {

            headers : {

                'Authorization' : 'Bearer ' + localStorage.getItem('tokenUserUp')

            }

        })

        if(response.data.sucesso === true ){

            setAdministradores(response.data.data)

        }

    }

    async function Apagar(idteam){

        // const response = await api.delete('',
        // {

        //     id : idteam

        // },
        // {

        //     headers : {

        //         'Authorization' : 'Bearer ' + localStorage.getItem('tokenUserUp')

        //     }

        // })

        console.log(idteam)

        // BuscarAdministradores()
        // BuscarColaboradores()

    }

    useEffect( () => {

        BuscarAdministradores()
        BuscarColaboradores()
        MostrarAdministradores()

    }, [] )

    function MostrarAdministradores(){

        document.getElementById('listColab').style.display = 'none'
        document.getElementById('listAdmins').style.display = 'flex'
        
        document.getElementById('buttonAdmin').style.backgroundColor = '#5E9CFF';
        document.getElementById('buttonAdmin').style.color = '#FFF';

        document.getElementById('buttonColab').style.backgroundColor = '#FFF';
        document.getElementById('buttonColab').style.color = '#5E9CFF';

    }

    function MostrarColaboradores(){

        document.getElementById('listColab').style.display = 'flex'
        document.getElementById('listAdmins').style.display = 'none'
        
        document.getElementById('buttonColab').style.backgroundColor = '#5E9CFF';
        document.getElementById('buttonColab').style.color = '#FFF';

        document.getElementById('buttonAdmin').style.backgroundColor = '#FFF';
        document.getElementById('buttonAdmin').style.color = '#5E9CFF';

    }

    return(

        <Container>
            <BackgroundEquipe>
                <ContentEquipe>
                    <TopPage>

                    <IconRedirect to='/Menu'>
                        <ArrowReturnLeft />
                    </IconRedirect>

                    <WrapperTittle>
                        <IAluno src={team} />
                        <TittleAluno>Ver equipe</TittleAluno>
                    </WrapperTittle>

                    <Logo src={logo} />

                    </TopPage>
                    <WrapperNav>

                        <RedirectButton id='buttonAdmin' onClick={MostrarAdministradores}>
                            Administradores
                        </RedirectButton>

                        <RedirectButton id={'buttonColab'} onClick={MostrarColaboradores}>
                            Colaboradores
                        </RedirectButton>

                    </WrapperNav>
                    <WrapperForm>
                        <FormSearch>
                            <InputSearch/>
                            <ButtonSearch readOnly value='Buscar'/>
                        </FormSearch>
                    </WrapperForm>

                    <ListTeam id='listColab'>

                        {

                            colaboradores.map( colab => {

                                return(
                                    <ItemList key={colab.id}>
                                        <ToolBar>
                                            <IconExclude onClick={ () => {Apagar(colab.id)} } />
                                        </ToolBar>
                                        <TextTeam>{colab.id}</TextTeam>
                                        <TittleTeam>{colab.nome}</TittleTeam>
                                        <TextTeam>{colab.email}</TextTeam>
                                    </ItemList>
                                )
                            } )

                        }

                    </ListTeam>

                    <ListTeam id='listAdmins'>

                        {

                            administradores.map( admins => {
                                return(

                                    <ItemList key={admins.id}>
                                        <ToolBar>
                                            <IconExclude onClick={ () => {Apagar(admins.id)} }/>
                                        </ToolBar>
                                        <TextTeam>{admins.id}</TextTeam>
                                        <TittleTeam>{admins.nome}</TittleTeam>
                                        <TextTeam>{admins.email}</TextTeam>
                                    </ItemList>

                                )

                            })

                        }

                    </ListTeam>
                    

                </ContentEquipe>
            </BackgroundEquipe>

        </Container>

    )

}