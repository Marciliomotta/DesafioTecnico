using System;
using System.Data.SqlClient;
using System.Data;
using Usuario.Models;
using Utils;
using System.Collections.Generic;

namespace Usuario.Controller
{
    public class C_Usuario
    {

        #region GET

        public List<M_Usuario> listagem()
        {
            using (var conn = new SqlConnection(StringConexao.DataBase))
            {
                var models = new List<M_Usuario>();
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                        conn.Open();

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"SELECT Usuario.id
                                                ,[nome]
                                                ,[cpf]
                                                ,[email]
                                                ,[dataNascimento]
                                                ,Perfil.id idPerfil
	                                            ,Perfil.descricao perfil
                                            FROM [Cadastro_Usuario].[dbo].[Usuario]
                                            INNER JOIN Perfil
	                                        ON Usuario.perfil = Perfil.id";
                        var dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            var model = new M_Usuario();
                            model.id = Convert.ToInt32(dr["id"]);
                            model.nome = dr["nome"].ToString();
                            model.cpf = dr["cpf"].ToString();
                            model.email = dr["email"].ToString();
                            model.dataNascimento = Convert.ToDateTime(dr["dataNascimento"]);
                            model.perfil.ID = Convert.ToInt32(dr["idPerfil"]);
                            model.perfil.Tipo = dr["perfil"].ToString();

                            models.Add(model);
                        }
                        dr.Close();
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }

                return models;
            }

        }

        #endregion

        #region Create

        public void Cadastrar(M_Usuario model)
        {
            using (var conn = new SqlConnection(StringConexao.DataBase))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                var trans = conn.BeginTransaction();
                try
                {

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        cmd.CommandText = @"INSERT INTO USUARIO
                                                (NOME,  
                                                EMAIL, 
                                                SENHA, 
                                                CPF, 
                                                DATANASCIMENTO, 
                                                PERFIL, 
                                                DATACRIACAO)
                                             VALUES
                                                (@NOME,  
                                                @EMAIL, 
                                                @SENHA, 
                                                @CPF, 
                                                @DATANASCIMENTO, 
                                                @PERFIL, 
                                                GETDATE()) SELECT SCOPE_IDENTITY();"
                        ;

                        cmd.Parameters.Add("@NOME", System.Data.SqlDbType.NVarChar).Value = model.nome;
                        cmd.Parameters.Add("@EMAIL", System.Data.SqlDbType.NVarChar).Value = model.email;
                        cmd.Parameters.Add("@SENHA", System.Data.SqlDbType.NVarChar).Value = model.senha;
                        cmd.Parameters.Add("@CPF", System.Data.SqlDbType.NVarChar).Value = model.cpf;
                        cmd.Parameters.Add("@DATANASCIMENTO", System.Data.SqlDbType.DateTime).Value = model.dataNascimento;
                        cmd.Parameters.Add("@PERFIL", System.Data.SqlDbType.Int).Value = model.perfil.ID;

                        var idRetorno = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.CommandText = @" INSERT INTO CONTATO(TELEFONE, USUARIOID)
                                             VALUES(@TELEFONE, @USUARIOID)";

                        cmd.Parameters.Add("@TELEFONE", System.Data.SqlDbType.NVarChar).Value = DBNull.Value;
                        cmd.Parameters.Add("@USUARIOID", System.Data.SqlDbType.Int).Value = idRetorno;

                        foreach (var contato in model.contatos)
                        {
                            cmd.Parameters["@TELEFONE"].Value = contato.telefone;

                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = @"INSERT INTO ENDERECO
                                               (USUARIOID
                                              ,CEP
                                              ,LOGRADOURO
                                              ,COMPLEMENTO
                                              ,NUMERO
                                              ,CIDADE
                                              ,ESTADO
                                              ,PAIS)
                                            VALUES(
                                               USUARIOID
                                              ,CEP
                                              ,LOGRADOURO
                                              ,COMPLEMENTO
                                              ,NUMERO
                                              ,CIDADE
                                              ,ESTADO
                                              ,PAIS)";

                        cmd.Parameters.Add("@CEP", System.Data.SqlDbType.NVarChar).Value = model.endereco.cep;
                        cmd.Parameters.Add("@LOGRADOURO", System.Data.SqlDbType.NVarChar).Value = model.endereco.logradouro;
                        cmd.Parameters.Add("@COMPLEMENTO", System.Data.SqlDbType.NVarChar).Value = model.endereco.complemento;
                        cmd.Parameters.Add("@NUMERO", System.Data.SqlDbType.NVarChar).Value = model.endereco.numero;
                        cmd.Parameters.Add("@CIDADE", System.Data.SqlDbType.NVarChar).Value = model.endereco.cidade;
                        cmd.Parameters.Add("@ESTADO", System.Data.SqlDbType.NVarChar).Value = model.endereco.estado;
                        cmd.Parameters.Add("@PAIS", System.Data.SqlDbType.NVarChar).Value = model.endereco.pais;

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        public void CadastrarContato(M_Contato model)
        {
            using (var conn = new SqlConnection(StringConexao.DataBase))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                try
                {

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @" INSERT INTO CONTATO(TELEFONE, USUARIOID)
                                             VALUES(@TELEFONE, @USUARIOID)";

                        cmd.Parameters.Add("@TELEFONE", System.Data.SqlDbType.NVarChar).Value = model.telefone;
                        cmd.Parameters.Add("@USUARIOID", System.Data.SqlDbType.Int).Value = model.usuarioID;

                        cmd.ExecuteNonQuery();

                    }

                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();
                }
            }

        }


        #endregion

        #region Update
        public void EditarEndereco(M_Endereco model)
        {
            using (var conn = new SqlConnection(StringConexao.DataBase))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"UPDATE ENDERECO
                                            SET CEP = @CEP, LOGRADOURO = @LOGRADOURO, COMPLEMENTO = @COMPLEMENTO, NUMERO = @NUMERO, CIDADE = @CIDADE, ESTADO = @ESTADO, PAIS = @PAIS
                                            WHERE usuarioID = @usuarioID"
                        ;

                        cmd.Parameters.Add("@CEP", System.Data.SqlDbType.NVarChar).Value = model.cep;
                        cmd.Parameters.Add("@LOGRADOURO", System.Data.SqlDbType.NVarChar).Value = model.logradouro;
                        cmd.Parameters.Add("@COMPLEMENTO", System.Data.SqlDbType.NVarChar).Value = model.complemento;
                        cmd.Parameters.Add("@NUMERO", System.Data.SqlDbType.NVarChar).Value = model.numero;
                        cmd.Parameters.Add("@CIDADE", System.Data.SqlDbType.NVarChar).Value = model.cidade;
                        cmd.Parameters.Add("@ESTADO", System.Data.SqlDbType.NVarChar).Value = model.estado;
                        cmd.Parameters.Add("@PAIS", System.Data.SqlDbType.NVarChar).Value = model.pais;

                        cmd.Parameters.Add("@usuarioID", System.Data.SqlDbType.Int).Value = model.usuarioID;

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        public void EditarUsuario(M_Usuario model)
        {
            using (var conn = new SqlConnection(StringConexao.DataBase))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"UPDATE Usuario
                                            SET NOME = @NOME,  EMAIL = @EMAIL, SENHA = @SENHA, CPF = @CPF, DATANASCIMENTO = @DATANASCIMENTO, PERFIL = @PERFIL, DATAALTERACAO = GETDATE()
                                            WHERE ID = @ID"
                        ;

                        cmd.Parameters.Add("@NOME", System.Data.SqlDbType.NVarChar).Value = model.nome;
                        cmd.Parameters.Add("@EMAIL", System.Data.SqlDbType.NVarChar).Value = model.email;
                        cmd.Parameters.Add("@SENHA", System.Data.SqlDbType.NVarChar).Value = model.senha;
                        cmd.Parameters.Add("@CPF", System.Data.SqlDbType.NVarChar).Value = model.cpf;
                        cmd.Parameters.Add("@DATANASCIMENTO", System.Data.SqlDbType.NVarChar).Value = model.dataNascimento;
                        cmd.Parameters.Add("@PERFIL", System.Data.SqlDbType.NVarChar).Value = model.perfil;

                        cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = model.id;

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        #endregion

        #region DELETE

        public void DeletarContato(int idContato)
        {
            using (var conn = new SqlConnection(StringConexao.DataBase))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"DELETE CONTATO WHERE ID = @ID"
                        ;

                        cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = idContato;

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        #endregion
    }
}
