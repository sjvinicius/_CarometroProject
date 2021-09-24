//Libs
import React, { useState, useEffect } from 'react'
import { useForm } from 'react-hook-form'

//Style
import { Container, Section, Aside, FormAside, TittleAside, InputAlunos, ButtonAlunos, IconClose, BackgroundAlunos, ContentAlunos, TopPage, IconRedirect, WrapperTittle, IAluno, TittleAluno, Logo, IconAdd, SubTopPage, FormBuscar, InputAluno, WrapperFile, LabelFile, SelectAlunos, OptionAluno, ListaAlunos, ItemAluno, ImgAluno, NomeAluno, InfoAluno, InputFile, DataAluno, WrapperRg, WrapperStatus, MorningIcon, AfternoonIcon, NightIcon, IconMgmt } from './styles'

//Imgs
import student from '../../Images/IconStudent.png'
import logo from '../../Images/logo.png'

//Icons
import { ArrowReturnLeft } from '@styled-icons/bootstrap/ArrowReturnLeft'

//Services
import api from '../../Services/api/apiStudent'


const baseURL = 'http://localhost:5000/Images/'



export default function BodyAlunos() {

    const { register, handleSubmit } = useForm();
    const [alunos, setAlunos] = useState([]);


    //Effects
    useEffect(() => {

        BuscarAlunos();

    }, []);

    //Functions

    //Abrir Modal
    function Open() {
        document.getElementById("aside").style.visibility = "visible";
    }

    async function BuscarAlunos() {

        const response = await api.get('/student', {

            headers: {

                'Authorization': 'Bearer ' + localStorage.getItem('tokenUserUp')

            }

        })

        console.log(response)

        if (response.data.sucesso === true) {


            setAlunos(response.data.data)

        }

    }


    // Modal
    function AsideAlunos() {

        const [fotoValue, setFotoValue] = useState('Enviar Arquivo');
        
        // Fechar Modal
        function Close() {
            document.getElementById("aside").style.visibility = "hidden";
        }

        async function CadastrarAluno(data) {

            const formData = new FormData()
            formData.append('nome', data.nome)
            formData.append('turma', data.turma)
            formData.append('status', data.status)
            formData.append('rg', data.rg)
            formData.append('endereco', data.endereco)
            formData.append('numMatricula', data.nmat)
            formData.append('foto', data.file[0].name)
            formData.append('arquivoImagem', data.file[0])

            const response = await api.post('/student',

                formData,

                {

                    headers: {

                        'Authorization': 'Bearer ' + localStorage.getItem('tokenUserUp')

                    }
                    
                }

            )

            if( response.data.sucesso === true ){

                console.log('Sucesso no cadastro')
                Close();
                BuscarAlunos();

            }

        }

        function AlterNomeFile(){

            var input = document.querySelector("#file");
            setFotoValue(input.value)
            

        }

        

        return (

            <Section id='aside'>
                <Aside>
                    <FormAside onSubmit={handleSubmit(CadastrarAluno)}>
                        <IconClose onClick={Close} />
                        <TittleAside>Cadastrar aluno</TittleAside>
                        <InputAlunos placeholder='Nome' {...register('nome')} />
                        <InputAlunos placeholder='RG' {...register('rg')} />
                        <InputAlunos placeholder='Endereço' {...register('endereco')} />
                        <InputAlunos placeholder='Num. Matrícula' {...register('nmat')} />
                        <SelectAlunos placeholder='Status' {...register('status')}>
                            <OptionAluno value='' >---------</OptionAluno>
                            <OptionAluno value='1' >Concluido</OptionAluno>
                            <OptionAluno value='2' >Cursando</OptionAluno>
                            <OptionAluno value='3' >Expulso </OptionAluno>
                        </SelectAlunos>
                        <SelectAlunos placeholder='Turma' {...register('turma')}>
                            <OptionAluno value='' >---------</OptionAluno>
                            <OptionAluno value='0' >Manhã</OptionAluno>
                            <OptionAluno value='1' >Tarde</OptionAluno>
                            <OptionAluno value='2' >Noite</OptionAluno>
                        </SelectAlunos>
                        <WrapperFile>
                            <LabelFile htmlFor='file'>{fotoValue}</LabelFile>
                            <InputFile onInput={AlterNomeFile} {...register('file')} type="file" name='file' id='file' />
                        </WrapperFile>
                        <ButtonAlunos type='submit' value='Cadastrar' />
                    </FormAside>
                </Aside>
            </Section>

        )

    }

    return (

        <Container>

            <BackgroundAlunos>
                <ContentAlunos>
                    <TopPage>

                        <IconRedirect to='/Menu'>
                            <ArrowReturnLeft />
                        </IconRedirect>

                        <WrapperTittle>
                            <IAluno src={student} />
                            <TittleAluno>Ver alunos</TittleAluno>
                        </WrapperTittle>

                        <Logo src={logo} />

                    </TopPage>
                    <SubTopPage>
                        <FormBuscar>
                            <InputAluno />
                            <ButtonAlunos type='submit' value='Buscar' />
                        </FormBuscar>

                        <IconAdd onClick={Open} />
                    </SubTopPage>
                    
                    <ListaAlunos>

                    {/* INSIRA O FOREACH AQUI */}

                    {

                        alunos.map( aluno => {

                            return(
                                    <ItemAluno key={aluno.id}>
                                        <ImgAluno src={baseURL + aluno.foto}/>
                                        <InfoAluno>
                                            <NomeAluno>{aluno.nome}</NomeAluno>
                                            <WrapperRg>
                                                <DataAluno>{aluno.rg}</DataAluno>
                                                <DataAluno>{aluno.numMatricula}</DataAluno>
                                            </WrapperRg>
                                            <DataAluno>{
                                            
                                                aluno.status === 1 ? 'Cursando':
                                                aluno.status === 2 ? 'Concluído':
                                                                     'Expulso'
                                            
                                            }</DataAluno>
                                        </InfoAluno>
                                        <WrapperStatus>
                                            {/* Manha/ Tarde / Noite */}

                                            {
                                                aluno.turma === 0 ? <MorningIcon/> : 
                                                aluno.turma === 1 ? <AfternoonIcon/> :
                                                                     <NightIcon/>
                                            
                                            }

                                            {/* <IconMgmt onClick={AtualizarAluno}/> */}
                                            <IconMgmt />
                                        </WrapperStatus>
                                    </ItemAluno>
                                
                            )

                        })

                    }

                    </ListaAlunos>

                </ContentAlunos>
            </BackgroundAlunos>
            <AsideAlunos />

        </Container>

    )

}