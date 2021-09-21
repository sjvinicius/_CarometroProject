// Libs
import React from 'react'

// Style
import {Container, WrapperTittle, WrapperContent, ContentBanner, Tittle, SubTittle, Paragraph, BackgroundParagraph, WrapperRedirect, ContentButton, Redirect, IconRedirect } from './styles'

export default function BodyHome(params) {
    
    return(

        <Container>
            <WrapperTittle>
                <Tittle>Carômetro</Tittle>
            </WrapperTittle>
            
            <WrapperContent>
                <ContentBanner>
                    <SubTittle>O que é o Carômetro ?</SubTittle>

                    <BackgroundParagraph>
                        <Paragraph>O carômetro é um projeto especial organizado e realizado por alunos da escola SENAI de Informática, para que através deste sejam capazes de aplicar os conhecimentos das atividades realizadas no 1º período do 3º semestre do curso de Desenvolvimento de Sistemas utilizando ORM, Inteligencia Artificial, Banco de Dados, Trabalho em Equipe e muito mais.</Paragraph>
                    </BackgroundParagraph>
                </ContentBanner>
            
            </WrapperContent>

            
            <WrapperRedirect>
                <ContentButton>
                    <Redirect to="Login" >Ir para login<IconRedirect/></Redirect>
                </ContentButton>
            </WrapperRedirect>

            
        </Container>

    )

}