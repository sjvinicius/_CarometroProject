import React from 'react'

import {TittleMenu, Container, NomeUser, TypeUser, SubTittle, LogoMenu, Card, IconAluno, IconTeam, TittleCard, ButtonLogout, IconArrow } from './styles'

import logo from '../../Images/logo.png'
import student from '../../Images/IconStudent.png'
import team from '../../Images/IconTeam.png'


export default function BodyMenu(){

    function Logout(){

        localStorage.setItem('tokenUserUp', null)

    }

    return(

        <Container>
            
            <TittleMenu>Saudações</TittleMenu>
            <NomeUser>$Nome</NomeUser>
            <TypeUser>$TipoUsuario</TypeUser>
            <SubTittle>Como eu posso te ajudar ?</SubTittle>
            <LogoMenu src={logo} />
            <Card to='/Alunos'>
                <IconAluno src={student}/>
                <TittleCard>Ver alunos</TittleCard>
            </Card>
            <Card to='/Alunos'>
                <IconTeam src={team} />
                <TittleCard>Ver Equipe</TittleCard>
            </Card>
            <ButtonLogout to='/Login' onClick={Logout} >
                <IconArrow />Logout
            </ButtonLogout>

        </Container>

    )

}