using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace ProvaTLP.Models
{
    public class Cerveja
    {

        private readonly static string _conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cervejaria;
Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Id { get; set; }

        public string Nome { get; set; }
        public string Tipo { get; set; }

        public short Ano { get; set; }
        public short Fabricacao { get; set; }

        public string Cor { get; set; }

        public byte Embalagem { get; set; }

        public bool Alcoolica { get; set; }

        public decimal Valor { get; set; }

        public bool Ativo { get; set; }

        public Cerveja() { }

        public Cerveja(int id, string nome, string tipo, short ano, short fabricacao, string cor, byte embalagem, bool alcoolica, decimal valor, bool ativo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
            Ano = ano;
            Fabricacao = fabricacao;
            Cor = cor;
            Embalagem = embalagem;
            Alcoolica = alcoolica;
            Valor = valor;
            Ativo = ativo;
        }

        public static List<Cerveja> GetCerveja()
        {

            var ListaCerveja = new List<Cerveja>();
            var sql = " SELECT * FROM Cerveja";
            try
            {

                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ListaCerveja.Add(new Cerveja(
                                        Convert.ToInt32(dr["Id"]),
                                        dr["Nome"].ToString(),
                                        dr["Tipo"].ToString(),
                                        Convert.ToInt16(dr["Ano"]),
                                        Convert.ToInt16(dr["Fabricacao"]),
                                        dr["Cor"].ToString(),
                                        Convert.ToByte(dr["Embalagem"]),
                                        Convert.ToBoolean(dr["Alcoolica"]),
                                        Convert.ToDecimal(dr["Valor"]),
                                        Convert.ToBoolean(dr["Ativo"])

                                        ));

                                }
                            }
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
            return ListaCerveja;
        }


        public void Salvar()
        {
            var  sql = "";
            if (Id == 0)
              sql = "INSERT INTO Cerveja (nome,tipo,ano,fabricacao,cor,embalagem,alcoolica,valor,ativo) VALUES (@nome,@tipo,@ano,@fabricacao,@cor,@embalagem,@alcoolica,@valor,@ativo)";

        else
                sql = "UPDATE Cerveja SET nome=@nome,tipo=@tipo,ano=@ano,fabricacao=@fabricacao,cor=@cor,embalagem=@embalagem,alcoolica=@alcoolica,valor=@valor,ativo=@ativo  WHERE id="  +Id;



            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql,cn))
                    {

                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@tipo", Tipo);
                        cmd.Parameters.AddWithValue("@ano", Ano);
                        cmd.Parameters.AddWithValue("@fabricacao", Fabricacao);
                        cmd.Parameters.AddWithValue("@Cor", Cor);
                        cmd.Parameters.AddWithValue("@embalagem", Embalagem);
                        cmd.Parameters.AddWithValue("@alcoolica", Alcoolica);
                        cmd.Parameters.AddWithValue("@valor",Valor);
                        cmd.Parameters.AddWithValue("@ativo", Ativo);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha " + ex.Message);
            }

                }

        public void GetCervejas(int id)
        {

            var sql = "SELECT nome, tipo, ano, fabricacao, cor, embalagem, alcoolica, valor,ativo FROM Cerveja WHERE id=" + id;

            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    Id = id;
                                    Nome = dr["Nome"].ToString();
                                    Tipo = dr["Tipo"].ToString();
                                    Ano = Convert.ToInt16(dr["ano"]);
                                    Fabricacao = Convert.ToInt16(dr["fabricacao"]);
                                    Cor = dr["Cor"].ToString();
                                    Embalagem = Convert.ToByte(dr["embalagem"]);
                                    Alcoolica = Convert.ToBoolean(dr["alcoolica"]);
                                    Valor = Convert.ToDecimal(dr["valor"]);
                                    Ativo = Convert.ToBoolean(dr["ativo"]);



                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Nome = "Falha: " + ex.Message;
                Console.WriteLine("Falha: " + ex.Message);
            }

        }

        public void Excluir ()
        {

            var sql = "DELETE FROM Cerveja WHERE id=" + Id;
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Falha:" + ex.Message);
            }


        }

    }
}