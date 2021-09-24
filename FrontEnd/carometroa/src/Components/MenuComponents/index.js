//Libs
import React from 'react'

//Styles
import {TittleMenu, Container, NomeUser, TypeUser, SubTittle, LogoMenu, Card, IconAluno, IconTeam, TittleCard, ButtonLogout, IconArrow } from './styles'

//Images
import logo from '../../Images/logo.png'
import student from '../../Images/IconStudent.png'
import team from '../../Images/IconTeam.png'

//Services
import tokenDecode from '../../Services/Cript/Auth'

//Varuaveus


export default function BodyMenu(){

    const infoUser = tokenDecode(localStorage.getItem('tokenUserUp'))
    
    function Logout(){

        localStorage.setItem('tokenUserUp', null)

    }

    return(

        <Container>
            {console.log(infoUser)}
            <TittleMenu>Saudações</TittleMenu>
            <NomeUser>{infoUser.family_name}</NomeUser>
            <TypeUser>{infoUser.role}</TypeUser>
            <SubTittle>Como eu posso te ajudar ?</SubTittle>
            <LogoMenu src={logo} />
            <Card to='/Alunos'>
                <IconAluno src={student}/>
                <TittleCard>Ver alunos</TittleCard>
            </Card>
            <Card to='/Equipe'>
                <IconTeam src={team} />
                <TittleCard>Ver Equipe</TittleCard>
            </Card>
            <ButtonLogout to='/Login' onClick={Logout} >
                <IconArrow />Logout
            </ButtonLogout>

        </Container>

    )

}