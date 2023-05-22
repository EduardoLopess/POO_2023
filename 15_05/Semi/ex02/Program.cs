using ex02.Models.Domain;

Escola escola = new Escola();

Professor professor = new Professor { Nome = "Teste Professor", Idade = 20 };
Aluno aluno = new Aluno { Nome = "Teste Aluno", Idade = 12 };

escola.ApresentarPessoa(professor);
escola.ApresentarPessoa(aluno);

      